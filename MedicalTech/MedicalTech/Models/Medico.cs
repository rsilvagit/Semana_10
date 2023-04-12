namespace MedicalTech.Models
{
    public class Medico:Pesssoa
    {
       public string InstEnsinoForm { get; set; }
       public string? Crm { get; set; }
       public string? EspClinica { get; set; }
       public bool StatusSistema { get; set; }
       public int TotalAtendimentos { get; set; }

    }
}
