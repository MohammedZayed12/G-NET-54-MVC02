using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagment.DataAccess.Entity
{
    public class Member : User
    {
        public string photo { get; set; } = null!;
        public DateTime joindate { get; set; }
        public HealthRecord healthRecord { get; set; } = null!;
        public ICollection<Booking> bookings { get; set; } = [];

        public ICollection<MemberShip> memberShips { get; set; }

    }
}
