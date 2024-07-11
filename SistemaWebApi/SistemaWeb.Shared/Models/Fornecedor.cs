namespace SistemaWeb.Shared.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cnpj { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public virtual Endereco Endereco { get; set; } = null!;
        public virtual List<Produto> Produtos { get; set; } = null!;

    }
}
