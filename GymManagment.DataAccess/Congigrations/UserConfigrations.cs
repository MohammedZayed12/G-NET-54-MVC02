using GymManagment.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;

namespace GymManagment.DataAccess.Congigrations
{
    public class UserConfigrations<T> : IEntityTypeConfiguration<T>
    where T : User
    {

        public virtual void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<T> builder)
        {
            builder.HasDiscriminator<string>("UserType")
                .HasValue<Member>("Member")
                .HasValue<Trainer>("Trainer");

            builder.Property(u => u.Name)
                 .HasMaxLength(100);
            builder.Property(u => u.Email)
                 .HasMaxLength(100);
            builder.Property(u => u.Phone)
                 .HasMaxLength(20);

            builder.OwnsOne(x => x.Address, a =>
            {
                a.Property(p => p.Street)
                .HasColumnName("Street")
                 .HasMaxLength(100);

                a.Property(p => p.City)
                .HasColumnName("City")
                 .HasMaxLength(50);
                a.Property(p => p.BuildingNumber)
                .HasColumnName("BuildingNumber");
             });

            builder.HasIndex(e => e.Email)
                .IsUnique();
            builder.HasIndex(p => p.Phone)
                .IsUnique();

            builder.ToTable(t =>
            {
                t.HasCheckConstraint("CK_User_Phone", "Len([Phone])=11 AND [Phone] LIKE '01[0125]%'");
            });

            // Apply a global query filter to exclude soft-deleted users           
            builder.HasQueryFilter(u => !u.IsDeleted);
        }
    }
}
