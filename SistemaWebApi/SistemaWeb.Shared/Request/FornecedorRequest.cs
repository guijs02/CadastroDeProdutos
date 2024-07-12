using SistemaWeb.Shared.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SistemaWeb.Shared.Request
{
    public record class FornecedorRequest
    {
        [Required]
        public string Nome { get; set; } = string.Empty;
        [Required]
        public string Cnpj { get; set; } = string.Empty;
        [JsonIgnore]
        public bool IsValidCnpj { get; set; }
        [Required]
        public string Telefone { get; set; } = string.Empty;
        [Required]
        [MinLength(8)]
        public string Cep { get; set; } = string.Empty;
        [JsonIgnore]
        public string Endereco { get; set; } = string.Empty;
        //public List<Produto> Produtos { get; set; } = null!;
        public List<ProdutoRequest> Produtos { get; set; } = null!;
    }
}
