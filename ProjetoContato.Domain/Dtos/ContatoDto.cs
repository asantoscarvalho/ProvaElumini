using System;
using System.ComponentModel.DataAnnotations;


namespace ProjetoContato.Domain.Dtos
{
    public class ContatoDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage="O nome do contato é obrigatório",AllowEmptyStrings=false)]
        public string Nome { get; set; }
        
        public DateTime? DataNascimento { get; set; }
        [Required(ErrorMessage="O sexo do contato é obrigatório",AllowEmptyStrings=false)]
        public string Sexo { get; set; }

         private int _idade = 0;

        public int Idade
        {
            get
            {
                if (this.DataNascimento.HasValue)
                {
                    _idade =(DateTime.Now.DayOfYear > this.DataNascimento.Value.DayOfYear) ?  DateTime.Now.Year - this.DataNascimento.Value.Year : (DateTime.Now.Year - this.DataNascimento.Value.Year)-1;

                }
                return _idade;
            }
            set
            {
                _idade = value;
            }
        }
 
    }
}