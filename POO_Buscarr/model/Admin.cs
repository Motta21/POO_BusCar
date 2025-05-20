using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Buscarr.model
{
    public class Monitor : User
    {
        private string cpf { get; set; }
        public Monitor(int userId, string name, string email, string password, string cpf) : base(userId, name, email, password)
        {
            this.cpf = cpf;
        }

    }
}
