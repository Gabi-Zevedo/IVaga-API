using Ivaga.Persistence.Contratos;
using IVaga.Application.Contratos;
using IVaga.Domain;
using IVaga.Persistence.Contratos;
using System;
using System.Threading.Tasks;

namespace IVaga.Application.Services
{
    public class VeiculoService : IVeiculoService

    {
        private readonly IVeiculoPersist _veiculoPersist;
        private readonly IGeralPersist _geralPersist;

        public VeiculoService(IGeralPersist geralPersist, IVeiculoPersist veiculoPersist)
        {
            _veiculoPersist = veiculoPersist;
            _geralPersist = geralPersist;
        }

        public async Task<Veiculo> AddVeiculo(Veiculo veiculo)
        {
            try
            {
                _geralPersist.Add<Veiculo>(veiculo);
                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _veiculoPersist.GetVeiculosByIdAsync(veiculo.Id);
                }
                return null;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public async Task<Veiculo> GetVeiculoByIdAsync(int veiculoId)
        {
            try
            {

                var veiculos = await _veiculoPersist.GetVeiculosByIdAsync(veiculoId);
                if (veiculos == null) return null;

                return veiculos;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<Veiculo[]> GetVeiculosAsync()
        {
            try
            {
                var veiculos = await _veiculoPersist.GetVeiculosAsync();
                if (veiculos == null) return null;

                return veiculos;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public async Task<Veiculo> UpdateVeiculo(int veiculoId, Veiculo veiculo)
        {
            try
            {
                var v = await _veiculoPersist.GetVeiculosByIdAsync(veiculoId);
                if (v == null) return null;

                veiculo.Id = v.Id;

                _geralPersist.Update<Veiculo>(veiculo);
                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _veiculoPersist.GetVeiculosByIdAsync(veiculo.Id);
                }
                return null;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public async Task<bool> DeleteVeiculo(int eventoId)
        {
            try
            {
                var v = await _veiculoPersist.GetVeiculosByIdAsync(eventoId);
                if (v == null) throw new Exception("Veículo não encontrado");

                _geralPersist.Delete<Veiculo>(v);
                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

    }
}
