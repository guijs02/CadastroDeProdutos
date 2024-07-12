using SistemaWeb.Shared.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace SistemaWeb.Shared.Request
{
    public record class ProdutoRequest
    {
        [Required]
        public string Descricao { get; set; } = null!;
        [Required]
        public string Marca { get; set; } = null!;
        [Required]
        public int FornecedorId { get; set; }
        [Required]
        public EUnidadeMedida Unidade { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero.")]
        public decimal ValorCompra { get; set; }
    }
}
