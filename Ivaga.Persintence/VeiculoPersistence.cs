using Ivaga.Persistence.Contratos;
using Ivaga.Persistence.Data;
using IVaga.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Ivaga.Persistence
{
    public class VeiculoPersistence : IVeiculoPersist
    {
        private readonly IVagaContext _context;

        public VeiculoPersistence(IVagaContext context)
        {
            _context = context;
        }
        public async Task<Veiculo[]> GetVeiculosAsync()
        {
            IQueryable<Veiculo> query = _context.Veiculos.AsNoTracking().OrderBy(v => v.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Veiculo> GetVeiculosByIdAsync(int veiculoId)
        {
            IQueryable<Veiculo> query = _context.Veiculos.AsNoTracking().OrderBy(v => v.Id).Where(v => v.Id == veiculoId);
            return await query.FirstOrDefaultAsync();
        }
    }
}
