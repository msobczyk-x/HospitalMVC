using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManager.Models
{
    public class Oddzial
    {
        [Key]
        public int OddzialID { get; set; }
        [Required]
        [StringLength(255)]
        public string Nazwa { get; set; }

        public string Opis { get; set; }

    }
}
