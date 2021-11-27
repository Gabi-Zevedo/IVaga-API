using IVaga.Domain;
using System.Threading.Tasks;

namespace IVaga.Application.Contratos
{
    public interface IVeiculoService
    {

        Task<Veiculo> AddVeiculo(Veiculo veiculo);
        Task<Veiculo> UpdateVeiculo(int veiculoId, Veiculo veiculo);
        Task<bool> DeleteVeiculo(int veiculoId);
        Task<Veiculo[]> GetVeiculosAsync();
        Task<Veiculo> GetVeiculoByIdAsync(int veiculoId);
    }
}
