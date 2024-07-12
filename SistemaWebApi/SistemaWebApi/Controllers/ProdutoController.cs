using Microsoft.AspNetCore.Mvc;
using SistemaWeb.Shared.Constants;
using SistemaWeb.Shared.Exceptions;
using SistemaWeb.Shared.Request;
using SistemaWeb.Shared.Services;

namespace SistemaWeb.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _service;
        public ProdutoController(IProdutoService produtoService)
        {
            _service = produtoService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(ProdutoRequest request)
        {
            try
            {
                var result = await _service.CreateAsync(request);
                return StatusCode(201, result);
            }
            catch (DuplicateDataException e)
            {
                return StatusCode(500, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, ErrorMessages.ErroCriar);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(ProdutoRequest request, int id)
        {
            try
            {
                var result = await _service.UpdateAsync(request, id);
                if (result is false) return NotFound();
                return Ok(result);
            }
            catch (DuplicateDataException e)
            {
                return StatusCode(500, e.Message);
            }
            catch (NotFoundException e)
            {
                return NotFound(new { message = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, ErrorMessages.ErroAlterar);
            }
        }
        [HttpDelete("{id}/{fornecedorId}")]
        public async Task<IActionResult> DeleteAsync(int id, int fornecedorId)
        {
            try
            {
                var result = await _service.DeleteAsync(id, fornecedorId);
                if (result is false) return NotFound();
                return Ok(result);
            }
            catch(NotFoundException e)
            {
                return NotFound(new { message = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, ErrorMessages.ErroDeletar);
            }
        }
    }
}



