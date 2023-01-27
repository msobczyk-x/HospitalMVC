using System.ComponentModel.DataAnnotations;
using HospitalManager.Validators;

namespace HospitalManager.Models
{
    public class Pacjent
    {
        [Key]
        public int PacjentID { get; set; }
        [Required]
        [StringLength(128)]
        [Display(Name = "Imię")]
        public string Imie { get; set; }
        [Required]
        [StringLength(128)]
        public string Nazwisko { get; set; }
        public string ImieNazwisko => $"{Imie} {Nazwisko}";
        [PeselValidator]
        public string PESEL { get; set; }

        public string Adres { get; set; }

        [PhoneValidator]
        public string Telefon { get; set; }

    }
}
