using SistemaWeb.Shared.Constants;
using SistemaWeb.Shared.DTOs;
using SistemaWeb.Shared.Exceptions;
using SistemaWeb.Shared.Records;
using SistemaWeb.Shared.Repositories;
using SistemaWeb.Shared.Request;
using SistemaWeb.Shared.Rules;
using SistemaWeb.Shared.Services;
using System.Text.Json;

namespace SistemaWeb.Api.Services
{
    public class FornecedorService(IFornecedorRepository repository) : IFornecedorService
    {
        private readonly IFornecedorRepository _repository = repository;
        public async Task<FornecedorDto> CreateAsync(FornecedorRequest request)
        {
            var responseCep = await GetEnderecoAsync(request);

            request.Endereco = $"{responseCep.logradouro}, {responseCep.localidade}, {responseCep.uf}, {responseCep.bairro}";

            if (await _repository.ExistFornecedorDuplicado(request))
                throw new DuplicateDataException();

            if (!ValidarFormatarCnpj(request))
            {
                return new FornecedorDto { IsValidCnpj = false };
            }

            var result = await _repository.CreateAsync(request);

            result.IsValidCnpj = request.IsValidCnpj;

            return result;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<List<FornecedorDto>> GetAllByPagedAsync(int pageNumber, int pageSize)
        {
            return await _repository.GetAllByPagedAsync(pageNumber, pageSize);
        }

        public async Task<FornecedorDto> GetByIdAsync(int id)
        {
            var result = await _repository.GetByIdAsync(id);
            result.Id = id;
            return result;
        }

        public async Task<FornecedorDto> UpdateAsync(FornecedorRequest request, int id)
        {
            if (await _repository.ExistFornecedorDuplicado(request))
                throw new DuplicateDataException();

            var responseCep = await GetEnderecoAsync(request);
            request.Endereco = $"{responseCep.logradouro}, {responseCep.localidade}, {responseCep.uf}, {responseCep.bairro}";

            if (!ValidarFormatarCnpj(request))
            {
                return new FornecedorDto { IsValidCnpj = false };
            }

            var result = await _repository.UpdateAsync(request, id);

            result.IsValidCnpj = request.IsValidCnpj;

            return result;
        }

        public async Task<ResponseViaCep> GetEnderecoAsync(FornecedorRequest request)
        {
            try
            {
                using var httpClient = new HttpClient();
                var response = await httpClient.GetStringAsync(string.Format(ApiCep.Url, request.Cep));
                var endereco = JsonSerializer.Deserialize<ResponseViaCep>(response);
                return endereco;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        private bool ValidarFormatarCnpj(FornecedorRequest request)
        {
            var isValid = CnpjHelper.IsCnpj(request.Cnpj);

            if (!isValid)
            {
                request.IsValidCnpj = isValid;
                return isValid;
            };

            request.IsValidCnpj = isValid;

            request.Cnpj = CnpjHelper.FormatarCnpj(request.Cnpj);

            return isValid;
        }
    }
}
