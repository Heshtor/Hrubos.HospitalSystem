using Hrubos.HospitalSystem.Infrastructure.Identity;

namespace Hrubos.HospitalSystem.Infrastructure.Database.Seeding
{
    internal class RolesInit
    {
        public List<Role> GetRolesAMC()
        {
            List<Role> roles = new List<Role>();

            Role roleAdmin = new Role()
            {
                Id = 1,
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = "9cf14c2c-19e7-40d6-b744-8917505c3106"
            };

            Role roleDoctor = new Role()
            {
                Id = 2,
                Name = "Doctor",
                NormalizedName = "DOCTOR",
                ConcurrencyStamp = "be0efcde-9d0a-461d-8eb6-444b043d6660"
            };

            Role rolePatient = new Role()
            {
                Id = 3,
                Name = "Patient",
                NormalizedName = "PATIENT",
                ConcurrencyStamp = "29dafca7-cd20-4cd9-a3dd-4779d7bac3ee"
            };


            roles.Add(roleAdmin);
            roles.Add(roleDoctor);
            roles.Add(rolePatient);

            return roles;
        }
    }
}
