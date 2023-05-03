using Locacao.Model;

namespace Locacao.DTO
{
    public class CarroDTO
    {
        public int Codigo { get; set; }
        public string DescricaoCarro { get; set; }
        public int CodigoMarca { get; set; }
        public string DescricaoMarca { get; set; }
        public DateTime DataLocacao { get; set; }
    }
}
