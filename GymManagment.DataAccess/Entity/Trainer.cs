using GymManagment.DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagment.DataAccess.Entity
{
    public class Trainer : User
    {
        public Speciality speciality { get; set; }
        public DateTime hiredate { get; set; }

        public ICollection<Session> sessions { get; set; } = [];
    }
}
