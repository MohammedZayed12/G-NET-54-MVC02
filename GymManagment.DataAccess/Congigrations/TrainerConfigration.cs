using GymManagment.DataAccess.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagment.DataAccess.Congigrations
{
    public class TrainerConfigration : UserConfigrations<Trainer>
    {
        public override void Configure(EntityTypeBuilder<Trainer> builder)
        {
            base.Configure(builder);
            //Convert Enum Into String in DataBase
            builder.Property(p => p.speciality)
               .HasConversion<string>()
               .HasMaxLength(20);
                
        }
    }
}
