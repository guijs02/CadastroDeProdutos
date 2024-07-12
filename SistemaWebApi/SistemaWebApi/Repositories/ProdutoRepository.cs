using Microsoft.EntityFrameworkCore;
using SistemaWeb.Api.Context;
using SistemaWeb.Shared.Constants;
using SistemaWeb.Shared.DTOs;
using SistemaWeb.Shared.Exceptions;
using SistemaWeb.Shared.Models;
using SistemaWeb.Shared.Repositories;
using SistemaWeb.Shared.Request;

namespace SistemaWeb.Api.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private AppWebDbContext _context;
        public ProdutoRepository(AppWebDbContext context)
        {
            _context = context;
        }
        public async Task<ProdutoDto> CreateAsync(ProdutoRequest request)
        {
            var produto = new Produto
            {
                Descricao = request.Descricao,
                FornecedorId = request.FornecedorId,
                Marca = request.Marca,
                Unidade = request.Unidade,
                ValorCompra = request.ValorCompra
            };
            _context.Produto.Add(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task<bool> DeleteAsync(int id, int fornecedorId)
        {
            var produto = await _context.Produto.FirstOrDefaultAsync(w => w.Id == id && w.FornecedorId == fornecedorId);

            if (produto is null)
                throw new NotFoundException(ErrorMessages.ErroProdutoNaoEncontrado);

            _context.Produto.Remove(produto);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(ProdutoRequest request, int id)
        {
            var produto = await _context.Produto.FirstOrDefaultAsync(w => w.Id == id && w.FornecedorId == request.FornecedorId);

             if (produto is null)
                throw new NotFoundException(ErrorMessages.ErroProdutoNaoEncontrado);

            produto.Descricao = request.Descricao;
            produto.ValorCompra = request.ValorCompra;
            produto.FornecedorId = request.FornecedorId;
            produto.Marca = request.Marca;
            produto.Unidade = request.Unidade;

            _context.Produto.Update(produto);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ExistProdutoDuplicado(ProdutoRequest request)
        {
            return await _context.Produto
                                .AnyAsync(w =>
                                           w.Unidade == request.Unidade && w.Descricao == request.Descricao &&
                                           w.Marca == request.Marca && w.ValorCompra == request.ValorCompra
                                           );
        }
    }
}
