using System.Text.RegularExpressions;

namespace SistemaWeb.Shared.Rules
{
    public static class CnpjHelper
    {
        public static bool IsCnpj(string cnpj)
        {

            int[] multiplicador1 = [5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];
            int[] multiplicador2 = [6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];

            int soma;
            int resto;
            string digito;
            string tempCnpj;

            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpj.Length != 14)
                return false;

            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            resto = (soma % 11);

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;

            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }

        public static string FormatarCnpj(string cnpj)
        {
            if (string.IsNullOrWhiteSpace(cnpj))
            {
                throw new ArgumentException("CNPJ não pode ser nulo ou vazio.");
            }

            cnpj = Regex.Replace(cnpj, @"\D", ""); // Remove caracteres não numéricos

            if (cnpj.Length != 14)
            {
                throw new ArgumentException("CNPJ deve conter 14 dígitos.");
            }

            return System.Convert.ToUInt64(cnpj).ToString(@"00\.000\.000\/0000\-00");
        }
    }
}
