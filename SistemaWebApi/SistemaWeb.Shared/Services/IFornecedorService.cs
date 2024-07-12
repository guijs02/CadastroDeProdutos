using SistemaWeb.Shared.DTOs;
using SistemaWeb.Shared.Request;

namespace SistemaWeb.Shared.Services
{
    public interface IFornecedorService
    {
        Task<FornecedorDto> CreateAsync(FornecedorRequest request);
        Task<FornecedorDto> UpdateAsync(FornecedorRequest request, int id);
        Task<List<FornecedorDto>> GetAllByPagedAsync(int pageNumber, int pageSize);
        Task<FornecedorDto> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
}
