using Hrubos.HospitalSystem.Application.Abstraction;
using Hrubos.HospitalSystem.Domain.Entities;
using Hrubos.HospitalSystem.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Hrubos.HospitalSystem.Application.Implementation
{
    public class SystemSettingsAppService : ISystemSettingsAppService
    {
        private readonly HospitalSystemDbContext _hospitalSystemDbContext;

        public SystemSettingsAppService(HospitalSystemDbContext hospitalSystemDbContext)
        {
            _hospitalSystemDbContext = hospitalSystemDbContext;
        }

        public IList<SystemSetting> SelectAll()
        {
            return _hospitalSystemDbContext.SystemSettings.ToList();
        }

        public void Create(SystemSetting systemSetting)
        {
            _hospitalSystemDbContext.SystemSettings.Add(systemSetting);
            _hospitalSystemDbContext.SaveChanges();
        }

        public bool Delete(int id)
        {
            bool deleted = false;

            var systemSetting = GetById(id);

            if (systemSetting != null)
            {
                _hospitalSystemDbContext.SystemSettings.Remove(systemSetting);
                _hospitalSystemDbContext.SaveChanges();
                deleted = true;
            }

            return deleted;
        }

        public bool Edit(int id, SystemSetting newSystemSetting)
        {
            var systemSetting = GetById(id);

            if (systemSetting == null)
            {
                return false;
            }

            _hospitalSystemDbContext.Entry(systemSetting).CurrentValues.SetValues(newSystemSetting);
            _hospitalSystemDbContext.SaveChanges();

            return true;
        }

        public SystemSetting GetById(int id)
        {
            return _hospitalSystemDbContext.SystemSettings.FirstOrDefault(e => e.Id == id);
        }

        public int GetIntValue(string key, int defaultValue = 0)
        {
            var setting = _hospitalSystemDbContext.SystemSettings.FirstOrDefault(s => s.Key == key);

            if (setting != null && int.TryParse(setting.Value, out int result))
            {
                return result;
            }

            return defaultValue; // pokud neexistuje nebo není číslo, vrátím default hodnotu
        }
    }
}
