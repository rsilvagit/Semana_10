namespace MedicalTech.Models
{
    public class Pesssoa
    {
        public int Id { get; set; }
        public string? NomeCompleto { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? Cpf { get; set; }
        public string Telefone { get; set;}
    }
}
