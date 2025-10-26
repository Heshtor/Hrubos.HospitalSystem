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




            //Identity - User and Role initialization
            //roles must be added first
            RolesInit rolesInit = new RolesInit();
            modelBuilder.Entity<Role>().HasData(rolesInit.GetRolesAMC());

            //then, create users ...
            UserInit userInit = new UserInit();
            User admin = userInit.GetAdmin();
            User doctor = userInit.GetDoctor();

            //... and add them to the table
            modelBuilder.Entity<User>().HasData(admin, doctor);

            //and finally, connect the users with the roles
            UserRolesInit userRolesInit = new UserRolesInit();
            List<IdentityUserRole<int>> adminUserRoles = userRolesInit.GetRolesForAdmin();
            List<IdentityUserRole<int>> doctorUserRoles = userRolesInit.GetRolesForDoctor();
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(adminUserRoles);
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(doctorUserRoles);
        }
    }
}
