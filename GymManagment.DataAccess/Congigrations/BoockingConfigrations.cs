using GymManagment.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagment.DataAccess.Congigrations
{
    internal class BoockingConfigrations: IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.Property(b => b.IsAttended)
                   .HasDefaultValue(false);

             builder.HasIndex(x => new
            {
                x.MemberId,
                x.SessionId
            }).IsUnique();

             builder.ToTable(t =>
            {
                t.HasCheckConstraint(
                    "CK_Booking_Date",
                    "[Date] >= GETDATE()"
                );
            });

        }
}
}
