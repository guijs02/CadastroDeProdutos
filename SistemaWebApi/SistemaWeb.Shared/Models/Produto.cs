using SistemaWeb.Shared.DTOs;
using SistemaWeb.Shared.Enum;
using System.Text.Json.Serialization;

namespace SistemaWeb.Shared.Models
{
    public class Produto
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonIgnore]
        public int FornecedorId { get; set; }
        public string Descricao { get; set; } = null!;
        public string Marca { get; set; } = null!;
        public EUnidadeMedida Unidade { get; set; }
        public decimal ValorCompra { get; set; }

    }
}
