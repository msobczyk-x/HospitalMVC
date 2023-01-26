using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManager.Models
{
    public class Doktor
    {
        
        public int DoktorID { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string ImieNazwisko => $"{Imie} {Nazwisko} {Specjalizacja}";
        public string Specjalizacja { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public int OddzialID { get; set; }
        [ForeignKey("OddzialID")]
        public Oddzial? Oddzial { get; set; }


    }
}
