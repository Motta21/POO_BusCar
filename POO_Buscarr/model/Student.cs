using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Buscarr.model
{
    public class Student
    {
        public string name { get; set; }
        public string age { get; set; }
        public string responsible { get; set; }
        public string cpfResponsible { get; set; }

        public Student(string name, string age, string responsible, string cpfResponsible)
        {
            this.name = name;
            this.age = age;
            this.responsible = responsible;
            this.cpfResponsible = cpfResponsible;
        }
    }
}
