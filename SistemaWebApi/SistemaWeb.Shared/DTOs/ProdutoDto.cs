using SistemaWeb.Shared.Models;
using SistemaWeb.Shared.Models.Enum;

namespace SistemaWeb.Shared.DTOs
{
    public class ProdutoDto
    {
        public string Descricao { get; set; } = null!;
        public string Marca { get; set; } = null!;
        public EUnidadeMedida Unidade { get; set; }
        public decimal ValorCompra { get; set; }

        public static implicit operator ProdutoDto(Produto produto)
                        => new()
                        {
                            Descricao = produto.Descricao,
                            Marca = produto.Marca,
                            Unidade = produto.Unidade,
                            ValorCompra = produto.ValorCompra
                        };
    }
}
