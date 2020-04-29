using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoContato.Repository.Contexts;
using ProjetoContato.Repository.Interface;

namespace ProjetoContato.Repository
{
    public class Repository<T> : IRepository<T> where T : class 
    {
        private readonly ContatoDbContext _context;

        protected readonly DbSet<T> dbSet;

        public Repository(ContatoDbContext context)
       {
            this._context = context;

            this.dbSet = this._context.Set<T>();
        }

        public void Dispose()
        {
          this._context.Dispose();        
        }
         public void Add(T entity)
        {
            _context.Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }
        public void Update(T entity)
        {
            _context.Update(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
           return ( await _context.SaveChangesAsync()) > 0;
             
        }

    }
}