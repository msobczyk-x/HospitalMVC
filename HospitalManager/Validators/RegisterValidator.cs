using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

using HospitalManager.Areas.Identity.Data;
using HospitalManager.Models;

namespace HospitalManager.Validators
{
	[RegisterValidator]
	public class RegisterValidatorAttribute : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var register = (Pacjent)validationContext.ObjectInstance;
			if (register.Imie == register.Nazwisko)
			{
				return new ValidationResult("Imię i nazwisko muszą być różne");
			}
			return ValidationResult.Success;
		}
	}
}
