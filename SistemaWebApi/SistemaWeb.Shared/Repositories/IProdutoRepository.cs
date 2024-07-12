using SistemaWeb.Shared.DTOs;
using SistemaWeb.Shared.Request;

namespace SistemaWeb.Shared.Repositories
{
    public interface IProdutoRepository
    {
        Task<ProdutoDto> CreateAsync(ProdutoRequest request);
        Task<bool> UpdateAsync(ProdutoRequest request, int id);
        Task<bool> DeleteAsync(int id, int fornecedorId);
        Task<bool> ExistProdutoDuplicado(ProdutoRequest request);
    }
}