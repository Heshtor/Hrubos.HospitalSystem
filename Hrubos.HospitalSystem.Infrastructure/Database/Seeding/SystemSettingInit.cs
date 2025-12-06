using Hrubos.HospitalSystem.Domain.Entities;

namespace Hrubos.HospitalSystem.Infrastructure.Database.Seeding
{
    internal class SystemSettingInit
    {
        public List<SystemSetting> GenerateSystemSettings()
        {
            return new List<SystemSetting>()
            {
                new SystemSetting {
                    Id = 1,
                    Key = "MaxVaccinationsPerDay",
                    Value = "20"
                }
            };
        }
    }
}
