using coqueiros_modulo1_semana10_exercicio.Models;

namespace coqueiros_modulo1_semana10_exercicio.DTO
{
    public class CarroDto
    {
        public int Codigo { get; set; }
        public int CodigoMarca { get; set; }
        public string DescricaoCarro { get; set; }
        public string DescricaoMarca { get; set; }
        public DateTime DataLocacao { get; set; }  

    }
}
