using GymManagment.DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagment.DataAccess.Entity
{
    public class HealthRecord:BaseEntity
    {
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public BloodType BloodType { get; set; }
        public int memberid { get; set; }
        public Member member { get; set; } = null!;
    }
}
