using GymManagment.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagment.DataAccess.Congigrations
{
    
   public class HealthRecordConfigrations : IEntityTypeConfiguration<HealthRecord>
    {
        public void Configure(EntityTypeBuilder<HealthRecord> builder)
        {
            builder.Property(h => h.Height)
                .HasColumnType("decimal(5,2)")
                .IsRequired();

            builder.Property(h => h.Weight)
                .HasColumnType("decimal(5,2)")
                .IsRequired();

            builder.HasOne(h => h.member)
                .WithOne(m => m.healthRecord)
                .HasForeignKey<HealthRecord>(h => h.memberid)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(t =>
            {
                t.HasCheckConstraint(
                    "CK_HealthRecord_Height",
                    "[Height] > 0");

                t.HasCheckConstraint(
                    "CK_HealthRecord_Weight",
                    "[Weight] > 0");
            });

            builder.HasQueryFilter(h => !h.IsDeleted);
        }
    }
}
