using Microsoft.EntityFrameworkCore;
using SistemaWeb.Api.Context;
using SistemaWeb.Shared.DTOs;
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
                Endereco = new()
                {
                    Bairro = request.Endereco.Bairro,
                    Cep = request.Endereco.Cep,
                    Logradouro = request.Endereco.Logradouro,
                    Numero = request.Endereco.Numero,
                },
                Cnpj = request.Cnpj,
                Nome = request.Nome,
                Produtos = request.Produtos,
                Telefone = request.Telefone
            };

            await _context.Fornecedor.AddAsync(fornecedor);
            await _context.SaveChangesAsync();
            return fornecedor;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _context.Fornecedor.FirstOrDefaultAsync(w => w.Id == id);
            _context.Fornecedor.Remove(result);
            _context.SaveChanges();
            return true;
        }

        public async Task<List<FornecedorDto>> GetAllAsync()
        {
            return await (from f in _context.Fornecedor
                          select new FornecedorDto()
                          {
                              Cnpj = f.Cnpj,
                              Endereco = f.Endereco,
                              Nome = f.Nome,
                              Produtos = f.Produtos,
                              Telefone = f.Telefone
                          }).ToListAsync();
        }

        public async Task<FornecedorDto> GetByIdAsync(int id)
        {
            return await _context.Fornecedor.FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task<bool> UpdateAsync(FornecedorRequest request, int id)
        {
            var result = await _context.Fornecedor.FirstOrDefaultAsync(w => w.Id == id);

            result.Nome = request.Nome;
            result.Produtos = request.Produtos;
            result.Telefone = request.Telefone;
            result.Cnpj = request.Cnpj;
            result.Endereco = result.Endereco;

            _context.Update(result);
            _context.SaveChanges();

            return true;
        }
    }
}
