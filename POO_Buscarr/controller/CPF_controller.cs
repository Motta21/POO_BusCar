using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Buscarr.controller
{

    public static class CPFController
    {
        public static bool ValidateCpf(string cpf)
        {
            // Limpa o CPF, mantendo apenas dígitos
            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            // Verifica tamanho e dígitos repetidos
            if (cpf.Length != 11 || AllDigitsEqual(cpf))
            {
                Console.WriteLine("CPF inválido: formato incorreto");
                return false;
            }

            // Converte para array de inteiros
            int[] cpfArray = cpf.Select(c => int.Parse(c.ToString())).ToArray();

            // Valida dígitos verificadores
            bool isValid = ValidateVerificationDigits(cpfArray);

            Console.WriteLine(isValid ? "CPF válido" : "CPF inválido");
            return isValid;
        }

        private static bool AllDigitsEqual(string cpf)
        {
            return cpf.All(c => c == cpf[0]);
        }

        private static bool ValidateVerificationDigits(int[] cpf)
        {
            // Valida primeiro dígito
            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                sum += cpf[i] * (10 - i);
            }

            int remainder = sum % 11;
            int firstDigit = (remainder < 2) ? 0 : 11 - remainder;

            if (cpf[9] != firstDigit)
                return false;

            // Valida segundo dígito
            sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sum += cpf[i] * (11 - i);
            }

            remainder = sum % 11;
            int secondDigit = (remainder < 2) ? 0 : 11 - remainder;

            return cpf[10] == secondDigit;
        }
    }
}


