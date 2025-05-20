using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Buscarr.controller
{
    public static class CNPJController
    {
        public static bool ValidateCnpj(string cnpj)
        {
            // Remove caracteres não numéricos
            cnpj = new string(cnpj.Where(char.IsDigit).ToArray());

            // Verifica se tem 14 dígitos
            if (cnpj.Length != 14)
            {
                Console.WriteLine("CNPJ inválido: deve conter 14 dígitos");
                return false;
            }

            // Verifica se todos os dígitos são iguais
            if (AllDigitsEqual(cnpj))
            {
                Console.WriteLine("CNPJ inválido: dígitos repetidos");
                return false;
            }

            // Converte para array de inteiros
            int[] cnpjArray = cnpj.Select(c => int.Parse(c.ToString())).ToArray();

            // Valida dígitos verificadores
            bool isValid = ValidateVerificationDigits(cnpjArray);

            Console.WriteLine(isValid ? "CNPJ válido" : "CNPJ inválido");
            return isValid;
        }

        private static bool AllDigitsEqual(string cnpj)
        {
            return cnpj.All(c => c == cnpj[0]);
        }

        private static bool ValidateVerificationDigits(int[] cnpj)
        {
            // Peso para cálculo do primeiro dígito
            int[] firstDigitWeights = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            // Peso para cálculo do segundo dígito
            int[] secondDigitWeights = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            // Valida primeiro dígito verificador
            int sum = 0;
            for (int i = 0; i < 12; i++)
            {
                sum += cnpj[i] * firstDigitWeights[i];
            }

            int remainder = sum % 11;
            int firstDigit = (remainder < 2) ? 0 : 11 - remainder;

            if (cnpj[12] != firstDigit)
                return false;

            // Valida segundo dígito verificador
            sum = 0;
            for (int i = 0; i < 13; i++)
            {
                sum += cnpj[i] * secondDigitWeights[i];
            }

            remainder = sum % 11;
            int secondDigit = (remainder < 2) ? 0 : 11 - remainder;

            return cnpj[13] == secondDigit;
        }

        public static string FormatCnpj(string cnpj)
        {
            if (!ValidateCnpj(cnpj))
                return cnpj;

            return Convert.ToUInt64(cnpj).ToString(@"00\.000\.000\/0000\-00");
        }

        // Lista de CNPJs inválidos conhecidos
        private static readonly string[] InvalidCnpjs =
        {
            "00000000000000", "11111111111111", "22222222222222",
            "33333333333333", "44444444444444", "55555555555555",
            "66666666666666", "77777777777777", "88888888888888",
            "99999999999999"
        };

        public static bool IsNotKnownInvalid(string cnpj)
        {
            string cleaned = new string(cnpj.Where(char.IsDigit).ToArray());
            return !InvalidCnpjs.Contains(cleaned);
        }
    }
}
