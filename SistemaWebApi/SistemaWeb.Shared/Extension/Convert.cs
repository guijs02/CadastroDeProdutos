using SistemaWeb.Shared.Models;
using SistemaWeb.Shared.Request;

namespace SistemaWeb.Shared.Extension
{
    public static class Convert
    {
        public static List<Produto> ConvertToProduto(this List<ProdutoRequest> listProdutos)
        {
            List<Produto> produtos = [];
            foreach (var produto in listProdutos)
            {
                produtos.Add(new Produto
                {
                    Id = produto.Id,
                    Descricao = produto.Descricao,
                    FornecedorId = produto.FornecedorId,
                    Marca = produto.Marca,
                    Unidade = produto.Unidade,
                    ValorCompra = produto.ValorCompra
                });
            }
            return produtos;
        }
    }
}
