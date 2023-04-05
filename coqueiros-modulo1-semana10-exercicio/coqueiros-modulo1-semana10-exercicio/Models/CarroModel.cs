using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace coqueiros_modulo1_semana10_exercicio.Models
{
    [Table("Carro")]
    public class CarroModel
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        
        [ForeignKey("MarcaModel")]
        public List<MarcaModel>? Marca { get; set; }
        public DateTime DataLocacao { get; set; }


        
        
    }
}
