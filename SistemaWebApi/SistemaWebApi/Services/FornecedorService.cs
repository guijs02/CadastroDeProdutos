using SistemaWeb.Shared.DTOs;
using SistemaWeb.Shared.Repositories;
using SistemaWeb.Shared.Request;
using SistemaWeb.Shared.Services;

namespace SistemaWeb.Api.Services
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository _repository;
        public FornecedorService(IFornecedorRepository repository)
        {
            _repository = repository;   
        }
        public async Task<FornecedorDto> CreateAsync(FornecedorRequest request)
        {
            var result = await _repository.CreateAsync(request);
            return result;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _repository.DeleteAsync(id);
            return result;
        }

        public async Task<List<FornecedorDto>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();
            return result;
        }

        public async Task<FornecedorDto> GetByIdAsync(int id)
        {
            var result = await _repository.GetByIdAsync(id);
            return result;
        }

        public async Task<bool> UpdateAsync(FornecedorRequest request, int id)
        {
            var result = await _repository.UpdateAsync(request, id);
            return result;
        }
    }
}
