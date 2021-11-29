using IVaga.Domain;
using System.Threading.Tasks;

namespace Ivaga.Persistence.Contratos
{
    public interface IVeiculoPersist
    {
        Task<Veiculo[]> GetVeiculosAsync();
        Task<Veiculo> GetVeiculosByIdAsync(int veiculoId);
    }
}
