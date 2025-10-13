using System.ComponentModel.DataAnnotations.Schema;

namespace Hrubos.HospitalSystem.Domain.Entities.Interfaces
{
    public interface IUser<TKey> : IEntity<TKey>
    {
        string? UserName { get; set; }
        string? Email { get; set; }
        string? PhoneNumber { get; set; }
        string? FirstName { get; set; }
        string? LastName { get; set; }
        string? BirthNumber { get; set; }
    }
}
