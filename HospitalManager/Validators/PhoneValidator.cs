using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using HospitalManager.Models;

namespace HospitalManager.Validators
{
    public class PhoneValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var pacjent = (Pacjent)validationContext.ObjectInstance;


            if (pacjent.Telefon == null)
                return new ValidationResult("Telefon jest wymagany.");

            var res = Regex.IsMatch(pacjent.Telefon, @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$");

            return (res==true)
                ? ValidationResult.Success
                : new ValidationResult("Telefon musi być podany w formie 9 cyfr.");
        }
    }
}
