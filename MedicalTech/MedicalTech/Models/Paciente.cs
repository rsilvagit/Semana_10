namespace MedicalTech.Models
{
    public class Paciente:Pesssoa
    {
        public string? ContatoDeEmergencia { get; set; }
        public List<string>ListaDeAlergias { get; set; }
        public List<string> ListaCuidadosEspecifios { get; set; }
        public string Convenio { get; set; }
        public string? StatusdeAtendimento { get; set; }
    }
}
