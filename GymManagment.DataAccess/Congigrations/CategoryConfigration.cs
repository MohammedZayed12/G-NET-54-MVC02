using GymManagment.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagment.DataAccess.Congigrations
{
    internal class CategoryConfigration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Name)
                .IsRequired()
                 .HasMaxLength(50);

            builder.Property(c => c.Description)
                .HasMaxLength(500)
                .IsRequired();

            builder.ToTable("Categories");

            builder.HasQueryFilter(c => !c.IsDeleted);

        }
    }
}
