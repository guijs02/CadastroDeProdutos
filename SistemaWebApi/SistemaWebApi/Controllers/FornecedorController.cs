using Microsoft.AspNetCore.Mvc;
using SistemaWeb.Shared.Constants;
using SistemaWeb.Shared.Exceptions;
using SistemaWeb.Shared.Request;
using SistemaWeb.Shared.Services;

namespace SistemaWeb.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
                
                if (!request.IsValidCnpj) return BadRequest(ErrorMessages.ErroCnpjInvalido);
                return StatusCode(201, result);
            }
            catch(DuplicateDataException e)
            {
                return StatusCode(500, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, ErrorMessages.ErroCriar);
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
                return StatusCode(500, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, ErrorMessages.ErroAlterar);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var fornecedores = await _service.GetAllAsync();
                if(!fornecedores.Any()) return NoContent();
                return Ok(fornecedores);
            }
            catch (Exception e)
            {
                return StatusCode(500, ErrorMessages.ErroBuscar);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var result = await _service.DeleteAsync(id);
                if(result is false) return NotFound();
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, ErrorMessages.ErroDeletar);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var result = await _service.GetByIdAsync(id);
                if(result ==  null) return NotFound();  
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, ErrorMessages.ErroBuscar);
            }
        }
    }
}
