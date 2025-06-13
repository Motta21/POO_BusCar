using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Buscarr.model
{
    public class Driver : User
    {
        private string cnh { get; set; }
        private string cpf { get; set; }
        public Driver(int userId, string name, string email, string password, string cpf, string cnh) : base(userId, name, email,cpf, password)
        {
            this.cnh = cnh;
            this.cpf = cpf;
        }
    }
}
