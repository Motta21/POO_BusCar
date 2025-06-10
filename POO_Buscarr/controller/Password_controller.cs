using System;
using System.Linq;

namespace POO_Buscarr.controller
{
    internal class Password_controller
    {
        public static bool Verify(string password)
        {
            // Verifica se a senha tem pelo menos 8 caracteres
            if (password.Length < 8)
            {
                return false;
            }
            // Verifica se a senha contém pelo menos uma letra maiúscula
            if (!password.Any(char.IsUpper))
            {
                return false;
            }
            // Verifica se a senha contém pelo menos uma letra minúscula
            if (!password.Any(char.IsLower))
            {
                return false;
            }
            // Verifica se a senha contém pelo menos um dígito
            if (!password.Any(char.IsDigit))
            {
                return false;
            }
            // Se todas as condições forem atendidas, a senha é válida
            return true;
        }

    }
}