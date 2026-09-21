using GymManagment.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagment.DataAccess.Congigrations
{
    public class MemberShipConfigration : IEntityTypeConfiguration<MemberShip> 
    { public void Configure(EntityTypeBuilder<MemberShip> builder) 
        {

            builder.HasOne(m => m.Member)
             .WithMany(m => m.memberShips)
             .HasForeignKey(m => m.MemberId)
             .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(m => m.Plan)
                .WithMany()
               .HasForeignKey(m => m.PlanId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("MemberShips", tableBuilder =>
            {
                tableBuilder.HasCheckConstraint
                ("CK_MemberShip_EndDate", "[EndDate] > [StartDate]");
            });
           
        }
    }
}
