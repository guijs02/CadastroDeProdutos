using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SistemaWeb.Shared.Constants;
using SistemaWeb.Shared.Exceptions;
using SistemaWeb.Shared.Request;
using SistemaWeb.Shared.Services;

namespace SistemaWeb.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorService _service;
        public FornecedorController(IFornecedorService fornecedorService)
        {
            _service = fornecedorService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(FornecedorRequest request)
        {
            try
            {
                var result = await _service.CreateAsync(request);

                if (!result.IsValidCnpj) return BadRequest(ErrorMessages.ErroCnpjInvalido);

                return StatusCode(201, result);
            }
            catch (DuplicateDataException e)
            {
                return StatusCode(500, new { message = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = ErrorMessages.ErroCriar });
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(FornecedorRequest request, int id)
        {
            try
            {
                var result = await _service.UpdateAsync(request, id);
                if (!request.IsValidCnpj) return BadRequest(ErrorMessages.ErroCnpjInvalido);
                return Ok(result);
            }
            catch (DuplicateDataException e)
            {
                return StatusCode(500, new { message = e.Message });
            }
            catch(NotFoundException e)
            {
                return NotFound(new { message = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = ErrorMessages.ErroAlterar });
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllByPagedAsync([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            try
            {
                if (pageNumber < 1 || pageSize < 1) return BadRequest(ErrorMessages.ErroParametrosMenorQueUm);

                var fornecedores = await _service.GetAllByPagedAsync(pageNumber, pageSize);
                if (fornecedores.Count == 0) return NoContent();
                return Ok(fornecedores);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = ErrorMessages.ErroBuscar });
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var result = await _service.DeleteAsync(id);
                return Ok(result);
            }
            catch (NotFoundException e)
            {
                return NotFound(new { message = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = ErrorMessages.ErroDeletar });
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var result = await _service.GetByIdAsync(id);

                return Ok(result);
            }
            catch (NotFoundException e)
            {
                return NotFound(new { message = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = ErrorMessages.ErroBuscar });
            }
        }
    }
}
