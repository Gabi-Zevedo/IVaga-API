using IVaga.Domain.Enums;

namespace IVaga.Domain
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public string Cor { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public TipoVeiculo TipoVeiculo { get; set; }

    }
}
