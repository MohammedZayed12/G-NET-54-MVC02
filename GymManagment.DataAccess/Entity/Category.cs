using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagment.DataAccess.Entity
{
    public class Category : BaseEntity
    {
         public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public ICollection<Session> sessions { get; set; } = [];

    }
}
