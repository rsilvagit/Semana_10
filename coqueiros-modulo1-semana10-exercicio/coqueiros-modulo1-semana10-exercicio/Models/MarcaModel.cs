using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace coqueiros_modulo1_semana10_exercicio.Models
{
    [Table("Marca")]
    public class MarcaModel
    {
        [Key]
        public int Id { get; set; }
        
        public string? Nome { get; set;}

    }
}
