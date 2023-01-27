using HospitalManager.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HospitalManager.Models;

namespace HospitalManager.Data;

public class HospitalManagerContext : IdentityDbContext<HospitalManagerUser>
{
    public HospitalManagerContext(DbContextOptions<HospitalManagerContext> options)
        : base(options)
    {
    }


    public DbSet<HospitalManager.Models.Oddzial> Oddzial { get; set; } = default!;

    public DbSet<HospitalManager.Models.Pacjent> Pacjent { get; set; }

    public DbSet<HospitalManager.Models.Doktor> Doktor { get; set; }

    public DbSet<HospitalManager.Models.Wizyta> Wizyta { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
