using SistemaWeb.Shared.Models;
using System.ComponentModel.DataAnnotations;

namespace SistemaWeb.Shared.Request
{
    public record class FornecedorRequest
    {
        [Required]
        public string Nome { get; set; } = string.Empty;
        [Required]
        public string Cnpj { get; set; } = string.Empty;
        [Required]
        public string Telefone { get; set; } = string.Empty;
        [Required]
        public EnderecoRequest Endereco { get; set; } = null!;
        public virtual List<ProdutoRequest> Produtos { get; set; } = null!;
    }
}
