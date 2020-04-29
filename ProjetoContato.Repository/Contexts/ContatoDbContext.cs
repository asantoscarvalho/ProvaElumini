using Microsoft.EntityFrameworkCore;
using ProjetoContato.Domain.Model;

namespace ProjetoContato.Repository.Contexts
{
    public class ContatoDbContext : DbContext
    {
        public ContatoDbContext(DbContextOptions options) : base (options) {}

        public DbSet<Contato> Contatos {get; set;}
    }
}