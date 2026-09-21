using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagment.DataAccess.Entity
{
    public class Address
    {
        public string Street { get; set; } = null!;
        public string City { get; set; } = null!;
        public int BuildingNumber { get; set; }
    }
}
