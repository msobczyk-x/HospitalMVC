using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManager.Models
{
    public class Doktor
    {
        [Key]
        public int DoktorID { get; set; }
        [Required]
        [StringLength(128)]
        [Display(Name = "Imię")]
        public string Imie { get; set; }
        [Required]
        [StringLength(128)]
        public string Nazwisko { get; set; }
        public string ImieNazwisko => $"{Imie} {Nazwisko} {Specjalizacja}";
        [Required]
        [StringLength(255)]

        public string Specjalizacja { get; set; }
        [Required]
        [Display(Name = "Adres zamieszkania")]
        public string Adres { get; set; }
        [Required(ErrorMessage = "Numer telefonu jest wymagany!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$",
            ErrorMessage = "Podany numer telefonu jest niepoprawny.")]
        [Display(Name = "Numer telefonu")]
        public string Telefon { get; set; }
        public int OddzialID { get; set; }
        [ForeignKey("OddzialID")]
        public Oddzial? Oddzial { get; set; }


    }
}
