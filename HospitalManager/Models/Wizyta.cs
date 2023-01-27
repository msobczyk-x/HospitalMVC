using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManager.Models
{
    public class Wizyta
    {
        [Key]
        public int WizytaID { get; set; }

        public int DoktorID { get; set; }
        [ForeignKey("DoktorID")] 
        public Doktor? Doktor { get; set; }

        public int PacjentID { get; set; }
        [ForeignKey("PacjentID")] 
        public Pacjent? Pacjent { get; set; }

        [DataType(DataType.Date)] public DateTime Data { get; set; }

        public string Opis { get; set; }

    }
}
