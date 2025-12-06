using Hrubos.HospitalSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Hrubos.HospitalSystem.Infrastructure.Database.Seeding;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Hrubos.HospitalSystem.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace Hrubos.HospitalSystem.Infrastructure.Database
{
    public class HospitalSystemDbContext : IdentityDbContext<User, Role, int>
    {
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<DoctorPatient> DoctorPatients { get; set; }
        public DbSet<ExaminationType> ExaminationTypes { get; set; }
        public DbSet<Examination> Examinations { get; set; }
        public DbSet<ExaminationResult> ExaminationResults { get; set; }
        public DbSet<VaccineType> VaccineTypes { get; set; }
        public DbSet<Vaccination> Vaccinations { get; set; }
        public DbSet<SystemSetting> SystemSettings { get; set; }

        public HospitalSystemDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.GetTableName()?.Replace("AspNet", String.Empty));
            }


            modelBuilder.Entity<Specialization>()
                .HasMany<User>(s => s.Doctors as IList<User>)
                .WithOne(u => u.Specialization)
                .HasForeignKey(u => u.SpecializationId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Examination>()
                .HasOne<User>(e => e.Patient as User)
                .WithMany(u => u.PatientExaminations)
                .HasForeignKey(e => e.PatientId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Examination>()
                .HasOne<User>(e => e.Doctor as User)
                .WithMany(u => u.DoctorExaminations)
                .HasForeignKey(e => e.DoctorId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Vaccination>()
                .HasOne<User>(e => e.Patient as User)
                .WithMany(u => u.Vaccinations)
                .HasForeignKey(e => e.PatientId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<DoctorPatient>()
                .HasOne<User>(dp => dp.Doctor as User)
                .WithMany(u => u.DoctorPatients)
                .HasForeignKey(dp => dp.DoctorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DoctorPatient>()
                .HasOne<User>(dp => dp.Patient as User)
                .WithMany(u => u.PatientDoctors)
                .HasForeignKey(dp => dp.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Specialization>().HasData(new SpecializationInit().GenerateSpecializations());

            // Přidání uživatelských rolí do tabulky
            modelBuilder.Entity<Role>().HasData(new RolesInit().GetRolesAMC());

            // Přidání uživatelů do tabulky
            modelBuilder.Entity<User>().HasData(new UserInit().GetAdmin());
            modelBuilder.Entity<User>().HasData(new UserInit().GetDoctors());
            modelBuilder.Entity<User>().HasData(new UserInit().GetPatients());

            // Přiřazení rolí uživatelům
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(new UserRolesInit().GetRoles());

            modelBuilder.Entity<DoctorPatient>().HasData(new DoctorPatientInit().GenerateDoctorPatients());

            modelBuilder.Entity<ExaminationType>().HasData(new ExaminationTypeInit().GenerateExaminationTypes());
            modelBuilder.Entity<Examination>().HasData(new ExaminationInit().GenerateExaminations());
            modelBuilder.Entity<ExaminationResult>().HasData(new ExaminationResultInit().GenerateExaminationResults());

            modelBuilder.Entity<VaccineType>().HasData(new VaccineTypeInit().GenerateVaccineTypes());
            modelBuilder.Entity<Vaccination>().HasData(new VaccinationInit().GenerateVaccinations());

            modelBuilder.Entity<SystemSetting>().HasData(new SystemSettingInit().GenerateSystemSettings());
        }
    }
}
