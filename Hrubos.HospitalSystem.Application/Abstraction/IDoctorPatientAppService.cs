using Hrubos.HospitalSystem.Domain.Entities;

namespace Hrubos.HospitalSystem.Application.Abstraction
{
    public interface IDoctorPatientAppService
    {
        IList<DoctorPatient> SelectAll();
        void Create(DoctorPatient doctorPatient);
        bool Delete(int id);
        bool Edit(int id, DoctorPatient doctorPatient);
        DoctorPatient GetById(int id);
    }
}
