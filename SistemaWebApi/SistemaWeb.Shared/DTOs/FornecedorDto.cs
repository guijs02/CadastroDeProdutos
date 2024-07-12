using SistemaWeb.Shared.Models;
using System.Text.Json.Serialization;

namespace SistemaWeb.Shared.DTOs
{
    public class FornecedorDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cnpj { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Cep { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public virtual List<Produto> Produtos { get; set; } = null!;
        [JsonIgnore]
        public bool IsValidCnpj { get; set; }

        public static implicit operator FornecedorDto(Fornecedor fornecedor)
                => new()
                {
                    Id = fornecedor.Id,
                    Cnpj = fornecedor.Cnpj,
                    Endereco = fornecedor.Endereco,
                    Nome = fornecedor.Nome,
                    Produtos = fornecedor.Produtos,
                    Cep = fornecedor.Cep,
                    Telefone = fornecedor.Telefone
                };
    }
}
