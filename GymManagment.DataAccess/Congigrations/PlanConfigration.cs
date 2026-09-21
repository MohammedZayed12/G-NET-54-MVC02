using GymManagment.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagment.DataAccess.Congigrations
{
    public class PlanConfigration : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            #region Property Configuration
            builder.Property(p => p.Name)
                .HasColumnType("nvarchar(50)")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.Description)
                 .HasColumnType("nvarchar(500)")
                 .HasMaxLength(500)
                 .IsRequired();

            builder.Property(p => p.Price)
                .HasColumnType("decimal(18,2)");
            #endregion

            #region Table Mapping & Constraints
            // Map to table and add check constraint for DurationDays
            builder.ToTable("Plans");
            builder.HasCheckConstraint("CK_Plan_DurationDays", "DurationDays BETWEEN 1 AND 365");
            #endregion

            builder.HasQueryFilter(p => !p.IsDeleted);

        }

    }
}
