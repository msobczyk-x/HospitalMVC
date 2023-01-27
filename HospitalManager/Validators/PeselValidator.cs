using HospitalManager.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace HospitalManager.Validators
{
    public class PeselValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var pacjent = (Pacjent)validationContext.ObjectInstance;


            if (pacjent.PESEL == null)
                return new ValidationResult("PESEL jest wymagany.");

            var res = Regex.IsMatch(pacjent.PESEL, @"^\d{11}$");

            return (res == true)
                ? ValidationResult.Success
                : new ValidationResult("Pesel musi być podany w formie 11 cyfr.");
        }
    }
}
