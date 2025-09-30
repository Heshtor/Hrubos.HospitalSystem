using Hrubos.HospitalSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

using Hrubos.HospitalSystem.Infrastructure.Database.Seeding;

namespace Hrubos.HospitalSystem.Infrastructure.Database
{
    public class HospitalSystemDbContext : DbContext
    {
        public DbSet<Specialization> Specializations { get; set; }

        public HospitalSystemDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            SpecializationInit specializationInit = new SpecializationInit();
            modelBuilder.Entity<SpecializationInit>().HasData(specializationInit.GenerateSpecializations3());
        }
    }
}
