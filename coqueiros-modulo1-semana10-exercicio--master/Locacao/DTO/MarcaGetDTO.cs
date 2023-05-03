namespace Locacao.DTO
{
    public class MarcaGetDTO
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public List<CarroGetDTO> ListaCarroGetDTO { get; set; }
    }

    public class CarroGetDTO
    {
        public int Codigo { get; set; }
        public string DescricaoCarro { get; set; }
        public int CodigoMarca { get; set; }
        public DateTime DataLocacao { get; set; }
    }
}
