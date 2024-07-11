using SistemaWeb.Shared.DTOs;
using SistemaWeb.Shared.Request;

namespace SistemaWeb.Shared.Services
{
    public interface IFornecedorService
    {
        Task<FornecedorDto> CreateAsync(FornecedorRequest request);
        Task<bool> UpdateAsync(FornecedorRequest request, int id);
        Task<List<FornecedorDto>> GetAllAsync();
        Task<FornecedorDto> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
}
