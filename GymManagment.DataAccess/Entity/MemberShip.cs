using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagment.DataAccess.Entity
{
    public class MemberShip : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int MemberId { get; set; }
        public Member Member { get; set; } = null!;

        public int PlanId { get; set; }
        public Plan Plan { get; set; } = null!;

     }
}
