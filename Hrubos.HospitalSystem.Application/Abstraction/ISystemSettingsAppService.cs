using Hrubos.HospitalSystem.Domain.Entities;

namespace Hrubos.HospitalSystem.Application.Abstraction
{
    public interface ISystemSettingsAppService
    {
        IList<SystemSetting> SelectAll();
        void Create(SystemSetting systemSetting);
        bool Delete(int id);
        bool Edit(int id, SystemSetting systemSetting);
        SystemSetting GetById(int id);
        int GetIntValue(string key, int defaultValue);
    }
}
