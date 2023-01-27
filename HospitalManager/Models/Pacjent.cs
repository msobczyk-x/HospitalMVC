using System.ComponentModel.DataAnnotations;

namespace HospitalManager.Models
{
    public class Pacjent
    {
        [Key]
        public int PacjentID { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string ImieNazwisko => $"{Imie} {Nazwisko}";
        public string PESEL { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }

    }
}
