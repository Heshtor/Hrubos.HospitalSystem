using Hrubos.HospitalSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Hrubos.HospitalSystem.Infrastructure.Database.Seeding;

namespace Hrubos.HospitalSystem.Infrastructure.Database
{
    public class HospitalSystemDbContext : DbContext
    {
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<DoctorPatient> DoctorPatients { get; set; }
        public DbSet<ExaminationType> ExaminationTypes { get; set; }
        public DbSet<Examination> Examinations { get; set; }
        public DbSet<ExaminationResult> ExaminationResults { get; set; }
        public DbSet<VaccineType> VaccineTypes { get; set; }
        public DbSet<Vaccination> Vaccinations { get; set; }

        public HospitalSystemDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<Specialization>();
            modelBuilder.Ignore<DoctorPatient>();
            modelBuilder.Ignore<Examination>();
            modelBuilder.Ignore<Vaccination>();

            //modelBuilder.Entity<Specialization>().HasData(new SpecializationInit().GenerateSpecializations());

            //modelBuilder.Entity<DoctorPatient>().HasData(new DoctorPatientInit().GenerateDoctorPatients());

            modelBuilder.Entity<ExaminationType>().HasData(new ExaminationTypeInit().GenerateExaminationTypes());
            //modelBuilder.Entity<Examination>().HasData(new ExaminationInit().GenerateExaminations());
            modelBuilder.Entity<ExaminationResult>().HasData(new ExaminationResultInit().GenerateExaminationResults());

            modelBuilder.Entity<VaccineType>().HasData(new VaccineTypeInit().GenerateVaccineTypes());
            //modelBuilder.Entity<Vaccination>().HasData(new VaccinationInit().GenerateVaccinations());
        }
    }
}
