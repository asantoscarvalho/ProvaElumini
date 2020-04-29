using System;
using System.Threading.Tasks;

namespace ProjetoContato.Repository.Interface
{
    public interface IRepository<T> : IDisposable where T: class
    {
          void Add(T entity);

         void Update(T entity);

         void Delete(T entity);
         
         Task<bool> SaveChangesAsync();
    }

}