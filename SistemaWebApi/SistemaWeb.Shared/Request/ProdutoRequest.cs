using SistemaWeb.Shared.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SistemaWeb.Shared.Request
{
    public record class ProdutoRequest
    {
        [JsonIgnore]
        public int Id { get; set; }
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
