using System.ComponentModel.DataAnnotations;

namespace Hrubos.HospitalSystem.Domain.Entities
{
    public class Specialization : Entity<int>
    {
        [Required]
        public string Name { get; set; }

        public IList<Doctor>? Doctors { get; set; }
    }
}
