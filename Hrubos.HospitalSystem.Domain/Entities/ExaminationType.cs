using System.ComponentModel.DataAnnotations;

namespace Hrubos.HospitalSystem.Domain.Entities
{
    public class ExaminationType : Entity<int>
    {
        [Required]
        public string Name { get; set; }

        public IList<Examination>? Examinations { get; set; }
    }
}
