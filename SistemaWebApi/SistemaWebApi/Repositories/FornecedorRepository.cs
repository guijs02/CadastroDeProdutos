using Microsoft.EntityFrameworkCore;
using SistemaWeb.Api.Context;
using SistemaWeb.Shared.Constants;
using SistemaWeb.Shared.DTOs;
using SistemaWeb.Shared.Exceptions;
using SistemaWeb.Shared.Extension;
using SistemaWeb.Shared.Models;
using SistemaWeb.Shared.Repositories;
using SistemaWeb.Shared.Request;

namespace SistemaWeb.Api.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private AppWebDbContext _context;
        public FornecedorRepository(AppWebDbContext context)
        {
            _context = context;
        }
        public async Task<FornecedorDto> CreateAsync(FornecedorRequest request)
        {
            var fornecedor = new Fornecedor
            {
                Cnpj = request.Cnpj,
                Endereco = request.Endereco,
                Cep = request.Cep,
                Nome = request.Nome,
                Produtos = request.Produtos.ConvertToProduto(),
                Telefone = request.Telefone
            };

            await _context.Fornecedor.AddAsync(fornecedor);
            await _context.SaveChangesAsync();
            return fornecedor;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _context.Fornecedor.FirstOrDefaultAsync(w => w.Id == id);

            if (result == null)
                throw new NotFoundException(ErrorMessages.ErroFornecedorNaoEncontrado);

            _context.Fornecedor.Remove(result);
            _context.SaveChanges();
            return true;
        }

        public async Task<List<FornecedorDto>> GetAllByPagedAsync(int pageNumber, int pageSize)
        {
            var totalRecords = _context.Fornecedor.Count();
            var totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);

            var fornecedores = await _context.Fornecedor
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(f => new FornecedorDto
                {
                    Id = f.Id,
                    Cnpj = f.Cnpj,
                    Endereco = f.Endereco,
                    Nome = f.Nome,
                    Produtos = f.Produtos,
                    Telefone = f.Telefone,
                    Cep = f.Cep,
                })
                .ToListAsync();

            return fornecedores;
        }

        public async Task<FornecedorDto> GetByIdAsync(int id)
        {
            return await _context.Fornecedor.Include(i => i.Produtos)
                                            .FirstOrDefaultAsync(w => w.Id == id) ??
                                                throw new NotFoundException(ErrorMessages.ErroFornecedorNaoEncontrado);
        }

        public async Task<FornecedorDto> UpdateAsync(FornecedorRequest request, int id)
        {
            var result = await _context.Fornecedor.FirstOrDefaultAsync(w => w.Id == id);

            if (result == null)
                throw new NotFoundException(ErrorMessages.ErroFornecedorNaoEncontrado);

            var produtos = request.Produtos.ConvertToProduto();

            result.Nome = request.Nome;
            result.Produtos = produtos;
            result.Telefone = request.Telefone;
            result.Cnpj = request.Cnpj;
            result.Endereco = request.Endereco;
            result.Cep = request.Cep;

            _context.Update(result);
            _context.SaveChanges();

            return new FornecedorDto
            {
                Id = id,
                Cep = request.Cep,
                Cnpj = request.Cnpj,
                Endereco = request.Endereco,
                IsValidCnpj = request.IsValidCnpj,
                Nome = request.Nome,
                Produtos = produtos,
                Telefone = request.Telefone,
            };
        }
        public async Task<bool> ExistFornecedorDuplicado(FornecedorRequest request)
        {
            var duplicado = await _context.Fornecedor.AnyAsync(a => a.Endereco == request.Endereco &&
                                                                a.Cep == request.Cep &&
                                                                a.Cnpj == request.Cnpj &&
                                                                a.Nome == request.Nome &&
                                                                a.Telefone == request.Telefone
                                                                );
            return duplicado;
        }
    }
}
