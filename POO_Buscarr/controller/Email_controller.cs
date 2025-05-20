using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace POO_Buscarr.controller
{
    internal class Email_controller
    {
        public static bool IsValid(string email)
        {
            try
            {
                var address = new MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
