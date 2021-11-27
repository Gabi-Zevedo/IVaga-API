using IVaga.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ivaga.Persistence.Contratos
{
    public interface IVeiculoPersist
    {
        Task<Veiculo[]> GetVeiculosAsync();
        Task<Veiculo> GetVeiculosByIdAsync(int veiculoId);
    }
}
