using System;

namespace ProjetoContato.Domain.Model
{
    public class Contato
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public DateTime? DataNascimento { get; set; }

        public string Sexo { get; set; }

    }
}