using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWeb.Shared
{
    public readonly record struct ResponseViaCep(string logradouro, string bairro, string localidade, string uf)
    {
    }
}
