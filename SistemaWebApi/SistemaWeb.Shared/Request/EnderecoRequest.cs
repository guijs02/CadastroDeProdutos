namespace SistemaWeb.Shared.Request
{
    public class EnderecoRequest
    {
        public string Cep { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Logradouro { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
    }
}
