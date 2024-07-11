using Microsoft.AspNetCore.Mvc;
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
                await _service.CreateAsync(request);
                return Ok(request);
            }
            catch (Exception e)
            {

                throw;
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(FornecedorRequest request)
        {
            try
            {
                await _service.UpdateAsync(request);
                return Ok(request);
            }
            catch (Exception e)
            {

                throw;
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var fornecedores = await _service.GetAllAsync();
                return Ok(fornecedores);
            }
            catch (Exception e)
            {

                throw;
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
            catch (Exception e)
            {
                throw;
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
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
