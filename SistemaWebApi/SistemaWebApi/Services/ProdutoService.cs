using SistemaWeb.Shared.DTOs;
using SistemaWeb.Shared.Exceptions;
using SistemaWeb.Shared.Repositories;
using SistemaWeb.Shared.Request;
using SistemaWeb.Shared.Services;

namespace SistemaWeb.Api.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository)
        {
            _repository = repository;
        }
        public async Task<ProdutoDto> CreateAsync(ProdutoRequest request)
        {
            if (await _repository.ExistProdutoDuplicado(request))
                throw new DuplicateDataException();

            return await _repository.CreateAsync(request);
        }

        public async Task<bool> DeleteAsync(int id, int fornecedorId)
        {
            return await _repository.DeleteAsync(id, fornecedorId);
        }

        public async Task<bool> UpdateAsync(ProdutoRequest request, int id)
        {
            if (await _repository.ExistProdutoDuplicado(request))
                throw new DuplicateDataException();

            return await _repository.UpdateAsync(request, id);
        }
    }
}
