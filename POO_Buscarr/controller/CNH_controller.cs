using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Buscarr.controller
{
    public static class CNHController
    {
        public static bool ValidateCnh(string cnh)
        {
            // Remove caracteres não numéricos
            cnh = new string(cnh.Where(char.IsDigit).ToArray());

            // Verifica se tem 11 dígitos
            if (cnh.Length != 11)
            {
                Console.WriteLine("CNH inválida: deve conter 11 dígitos");
                return false;
            }

            // Verifica se todos os dígitos são iguais
            if (AllDigitsEqual(cnh))
            {
                Console.WriteLine("CNH inválida: dígitos repetidos");
                return false;
            }

            // Calcula os dígitos verificadores
            return ValidateCnhDigits(cnh);
        }

        private static bool AllDigitsEqual(string cnh)
        {
            return cnh.All(c => c == cnh[0]);
        }

        private static bool ValidateCnhDigits(string cnh)
        {
            int[] numbers = cnh.Select(c => int.Parse(c.ToString())).ToArray();

            // Cálculo do primeiro dígito verificador
            int sum = 0;
            int weight = 9;
            for (int i = 0; i < 9; i++)
            {
                sum += numbers[i] * weight;
                weight--;
            }

            int firstDigit = sum % 11;
            firstDigit = firstDigit > 9 ? 0 : firstDigit;

            // Cálculo do segundo dígito verificador
            sum = 0;
            weight = 1;
            for (int i = 0; i < 9; i++)
            {
                sum += numbers[i] * weight;
                weight++;
            }

            int secondDigit = sum % 11;
            secondDigit = secondDigit > 9 ? 0 : secondDigit;

            // Verifica os dígitos
            bool isValid = numbers[9] == firstDigit && numbers[10] == secondDigit;

            Console.WriteLine(isValid ? "CNH válida" : "CNH inválida");
            return isValid;
        }

        public static string FormatCnh(string cnh)
        {
            if (!ValidateCnh(cnh))
                return cnh;

            return Convert.ToUInt64(cnh).ToString(@"000\.000\.000\-00");
        }
    }
}
