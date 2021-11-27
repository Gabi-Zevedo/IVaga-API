using IVaga.Domain;
using Microsoft.EntityFrameworkCore;

namespace Ivaga.Persistence.Data
{
    public class IVagaContext : DbContext
    {
        public IVagaContext(DbContextOptions<IVagaContext> options) : base(options)
        { 
        }

        public DbSet<Veiculo> Veiculos { get; set; }

    }
}

