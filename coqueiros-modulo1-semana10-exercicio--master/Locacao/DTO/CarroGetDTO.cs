namespace Locacao.DTO
{
    public class CarroMarcaGetDTO
    {
        public int Codigo { get; set; }
        public string DescricaoCarro { get; set; }
        public int CodigoMarca { get; set; }
        public DateTime DataLocacao { get; set; }
        public List<MarcaDTO> ListaMarcaDTO { get; set;}
    }
}
