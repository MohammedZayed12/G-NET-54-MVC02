using GymManagment.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagment.DataAccess.Congigrations
{
    public class SessionConfigration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.Property(s => s.Description)
                .HasMaxLength(500);
            builder.HasOne(s => s.Trainer)
              .WithMany(t => t.sessions)
              .HasForeignKey(s => s.TrainerId)
              .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Category)
                .WithMany(c => c.sessions)
                .HasForeignKey(s => s.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.ToTable(t =>
            {
                t.HasCheckConstraint(
                    "CK_Session_Capacity",
                    "[Capacity] > 0");

                t.HasCheckConstraint(
                    "CK_Session_EndDate",
                    "[EndDate] > [StartDate]");
            });
            builder.HasQueryFilter(p => !p.IsDeleted);

        }
    }
}
