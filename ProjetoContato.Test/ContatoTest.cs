using System;
using Xunit;
using ProjetoContato.Repository.Interface;
using ProjetoContato.Domain.Model;

namespace ProjetoContato.Test
{
    public class ContatoTest
    {
        private readonly IContatoRepository _repo;
        public ContatoTest(IContatoRepository repo)
        {
            this._repo = repo;
            
        }
 
        [Fact]
        public void RetornaContato()
        {

        }

        [Fact]
        public void GravarContato()
        {
            Contato _contato = new Contato {
                Nome = "Andre",
                DataNascimento = "25/12/2016",
                Sexo = "M"

            };

           _repo.Add(_contato);
            _repo.SaveChangesAsync();
            Assert.True(_contato.Id > 0);

        }

       /*  [Fact]
        public void RetornaContato_PorId()
        {

        }

        [Fact]
        public void RetornaContato_PorNome()
        {
                
        }

        [Fact]
        public void AlterarContato()
        {
                
        }

        [Fact]
        public void ExcluirContato()
        {
                
        } */


    }
}
