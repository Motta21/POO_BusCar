using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Buscarr.model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Password { get; set; }

        public User(int userId, string name, string email, string cpf, string password)
        {
            this.Id = userId;
            this.Name = name;
            this.Email = email;
            this.Cpf = cpf;
            this.Password = password;
        }

        public User()
        {
        }
    }
}
