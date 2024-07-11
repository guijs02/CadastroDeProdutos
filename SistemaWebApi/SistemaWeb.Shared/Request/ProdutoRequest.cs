using SistemaWeb.Shared.Enum;
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
        public decimal ValorCompra { get; set; }
    }
}
