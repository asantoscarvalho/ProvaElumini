using System.Threading.Tasks;
using ProjetoContato.Domain.Model;

namespace ProjetoContato.Repository.Interface
{
    public interface IContatoRepository : IRepository<Contato>
    {
        Task<Contato[]> GetContatoAsync();

        Task<Contato> GetContatoAsyncById(int ContatosId);

        Task<Contato[]> GetContatoAsyncByName(string Nome);
    }
}