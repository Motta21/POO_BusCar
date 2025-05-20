using System;
using System.Linq;
using System.Text;

namespace POO_Buscarr.controller
{
    internal class Password_controller
    {
        private string password;
        public Password_controller(string password)
        {
            this.password = password;
        }

        public string GetPassword()
        {
            return password;
        }

        public void SetPassword(string password)
        {
            this.password = password;
        }

        public string VerifyPassword(string password)
        {
            if (password.Length < 8)
            {
                return "Password must be at least 8 characters long.";
            }
            if (!HasUpperCase(password))
            {
                return "Password must contain at least one uppercase letter.";
            }
            if (!HasLowerCase(password))
            {
                return "Password must contain at least one lowercase letter.";
            }
            if (!HasDigit(password))
            {
                return "Password must contain at least one digit.";
            }
            if (!HasSpecialCharacter(password))
            {
                return "Password must contain at least one special character.";
            }
            return "Password is valid.";
        }

        private bool HasUpperCase(string password)
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

        private bool HasLowerCase(string password)
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

        private bool HasDigit(string password)
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

        private bool HasSpecialCharacter(string password)
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
