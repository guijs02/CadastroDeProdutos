using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SistemaWeb.Shared.Request
{
    public class EnderecoRequest
    {
        [JsonRequired]
        [Required]
        public string Cep { get; set; } = string.Empty;
        [JsonIgnore]
        public string Bairro { get; set; } = string.Empty;
        [JsonIgnore]
        public string Logradouro { get; set; } = string.Empty;
        [JsonIgnore]
        public string Numero { get; set; } = string.Empty;
    }
}
