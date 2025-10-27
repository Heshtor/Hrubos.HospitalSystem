using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hrubos.HospitalSystem.Domain.Entities
{
    [Table(nameof(SystemSetting))]
    public class SystemSetting : Entity<int>
    {
        [Required]
        public string Key { get; set; }
        [Required]
        public string Value { get; set; }
    }
}
