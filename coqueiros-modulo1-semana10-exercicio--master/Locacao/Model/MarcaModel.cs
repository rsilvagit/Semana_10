using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Locacao.Model
{
    [Table("MARCA")]
    public class MarcaModel
    {
        [Column("ID"),Key] public int ID { get; set; }
        [Column("NOME"), Required] public string Nome { get; set; }
        public ICollection<CarroModel> CarrosCollection { get; set; }
    }
}
