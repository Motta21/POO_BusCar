using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Buscarr.model
{
    public class Aluno
    {
        public int Id { get; set; }
        public string NomeAluno { get; set; }
        public int Idade { get; set; }
        public string Endereco { get; set; }
        public string Escola { get; set; }
        public string NomeResponsavel { get; set; }
        public string RgResponsavel { get; set; }
        public string TelefoneResponsavel { get; set; }
    }
}