using GymManagment.DataAccess.Enums;

namespace GymManagment.DataAccess.Entity
{
    public class User : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public DateOnly DateOfBirth { get; set; }
        public Gender gender { get; set; }
        public Address Address { get; set; } = null!;
    }
}
