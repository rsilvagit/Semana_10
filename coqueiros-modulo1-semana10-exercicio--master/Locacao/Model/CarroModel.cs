using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Locacao.Model
{
    [Table("CARRO")]
    public class CarroModel
    {
        [Column("ID"),Key] public int Id { get; set; }
        [Column("NOME"),Required] public string Nome { get; set; }
        [Column("DATA_LOCACAO")] public DateTime DataLocacao { get; set; }
        [Column("ID_MARCA"), ForeignKey("MarcaModel")] public int IdMarca { get; set; }   
        public MarcaModel Marca { get; set; }
    }
}
