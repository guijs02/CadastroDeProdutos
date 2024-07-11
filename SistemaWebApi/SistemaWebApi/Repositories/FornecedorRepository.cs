using SistemaWeb.Api.Context;
using SistemaWeb.Shared.DTOs;
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
        public Task<FornecedorDto> CreateAsync(FornecedorRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<FornecedorDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<FornecedorDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(FornecedorRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
