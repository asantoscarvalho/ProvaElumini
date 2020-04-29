using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoContato.Domain.Model;
using ProjetoContato.Repository.Contexts;
using ProjetoContato.Repository.Interface;


namespace ProjetoContato.Repository
{
    public class ContatoRepository  : Repository<Contato> , IContatoRepository
    {
         private readonly ContatoDbContext _context;

        public ContatoRepository(ContatoDbContext context) : base(context)
        {
            this._context = context;
        }



        public async Task<Contato[]> GetContatoAsync()
        {
            IQueryable<Contato> query = _context.Contatos;


            return await query.ToArrayAsync();
        }

        public async Task<Contato> GetContatoAsyncById(int ContatoId)
        {
            IQueryable<Contato> query = _context.Contatos;

            query = query.OrderBy(c => c.Nome).Where(c => c.Id == ContatoId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Contato[]> GetContatoAsyncByName(string Nome)
        {
            IQueryable<Contato> query = _context.Contatos;

            query = query.OrderBy(c => c.Nome).Where(c => c.Nome.Contains(Nome));

            return await query.ToArrayAsync();
        }
    }
}