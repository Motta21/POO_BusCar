using System;
using System.Linq;
using System.Text;

namespace POO_Buscarr.controller
{
    internal class Password_controller
    {

        public static bool IsValid(string password)
        {
            if (password.Length < 8)
            {
                return false;
            }
            if (!HasUpperCase(password))
            {
                return false;
            }
            if (!HasLowerCase(password))
            {
                return false;
            }
            if (!HasDigit(password))
            {
                return false;
            }
            if (!HasSpecialCharacter(password))
            {
                return false;
            }
            return false;
        }

        private static bool HasUpperCase(string password)
        {
            foreach (char c in password)
            {
                if (char.IsUpper(c))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool HasLowerCase(string password)
        {
            foreach (char c in password)
            {
                if (char.IsLower(c))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool HasDigit(string password)
        {
            foreach (char c in password)
            {
                if (char.IsDigit(c))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool HasSpecialCharacter(string password)
        {
            string specialCharacters = "!@#$%^&*()_+-=[]{}|;':\",.<>?/`~";
            foreach (char c in password)
            {
                if (specialCharacters.Contains(c))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
