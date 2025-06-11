namespace POO_Buscarr.model
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Endereco { get; set; }
        public string Escola { get; set; }
        public string NomeResponsavel { get; set; }
        public string CpfResponsavel { get; set; }
        public string TelefoneResponsavel { get; set; }

        public Aluno()
        {
            // Construtor padrão
        }

        public Aluno(string nome, int idade, string endereco, string escola,
                    string nomeResponsavel, string cpfResponsavel, string telefoneResponsavel)
        {
            Nome = nome;
            Idade = idade;
            Endereco = endereco;
            Escola = escola;
            NomeResponsavel = nomeResponsavel;
            CpfResponsavel = cpfResponsavel;
            TelefoneResponsavel = telefoneResponsavel;
        }
    }
}