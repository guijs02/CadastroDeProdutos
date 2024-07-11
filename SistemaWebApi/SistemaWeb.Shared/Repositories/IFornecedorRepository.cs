using SistemaWeb.Shared.DTOs;
using SistemaWeb.Shared.Request;

namespace SistemaWeb.Shared.Repositories
{
    public interface IFornecedorRepository
    {
        Task<FornecedorDto> CreateAsync(FornecedorRequest request);
        Task UpdateAsync(FornecedorRequest request);
        Task<List<FornecedorDto>> GetAllAsync();
        Task<FornecedorDto> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
}
