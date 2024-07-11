using SistemaWeb.Shared.Models;

namespace SistemaWeb.Shared.DTOs
{
    public class FornecedorDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cnpj { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public virtual Endereco Endereco { get; set; } = null!;
        public virtual List<Produto> Produtos { get; set; } = null!;

        public static implicit operator FornecedorDto(Fornecedor fornecedor)
                => new()
                {
                    Cnpj = fornecedor.Cnpj,
                    Endereco = fornecedor.Endereco,
                    Nome = fornecedor.Nome,
                    Produtos = fornecedor.Produtos,
                    Telefone = fornecedor.Telefone
                };
    }
}
