using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;

namespace HospitalManager.Areas.Identity.Data;

// Add profile data for application users by adding properties to the HospitalManagerUser class
public class HospitalManagerUser : IdentityUser
{
    [PersonalData]
	[Required]
	public string Imie { get; set; }
    [Required]
    [PersonalData]
    public string Nazwisko { get; set; }
}

