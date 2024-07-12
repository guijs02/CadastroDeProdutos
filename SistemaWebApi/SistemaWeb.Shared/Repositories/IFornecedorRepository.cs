using SistemaWeb.Shared.DTOs;
using SistemaWeb.Shared.Request;

namespace SistemaWeb.Shared.Repositories
{
    public interface IFornecedorRepository
    {
        Task<FornecedorDto> CreateAsync(FornecedorRequest request);
        Task<FornecedorDto> UpdateAsync(FornecedorRequest request, int id);
        Task<List<FornecedorDto>> GetAllByPagedAsync(int pageNumber, int pageSize);
        Task<FornecedorDto> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistFornecedorDuplicado(FornecedorRequest request);
    }
}
