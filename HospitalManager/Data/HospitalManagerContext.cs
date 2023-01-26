using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HospitalManager.Models;

namespace HospitalManager.Data
{
    public class HospitalManagerContext : DbContext
    {
        public HospitalManagerContext (DbContextOptions<HospitalManagerContext> options)
            : base(options)
        {
        }

        public DbSet<HospitalManager.Models.Oddzial> Oddzial { get; set; } = default!;

        public DbSet<HospitalManager.Models.Pacjent> Pacjent { get; set; }

        public DbSet<HospitalManager.Models.Doktor> Doktor { get; set; }

        public DbSet<HospitalManager.Models.Wizyta> Wizyta { get; set; }
    }
}
