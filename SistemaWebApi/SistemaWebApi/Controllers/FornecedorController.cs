using Microsoft.AspNetCore.Mvc;
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
                return StatusCode(201, result);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Ocorreu um erro buscar ao criar");
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(FornecedorRequest request, int id)
        {
            try
            {
                var result = await _service.UpdateAsync(request, id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Ocorreu um erro buscar ao alterar");
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
                return StatusCode(500, "Ocorreu um erro buscar ao buscar");
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
                return StatusCode(500, "Ocorreu um erro buscar ao deletar");
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
                return StatusCode(500, "Ocorreu um erro buscar o registro");
            }
        }
    }
}
