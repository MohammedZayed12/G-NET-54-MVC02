using GymManagment.DataAccess.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagment.DataAccess.Congigrations
{
    public class MemberConfigration : UserConfigrations<Member>
    {
        public override void Configure(EntityTypeBuilder<Member> builder)
        {
            base.Configure(builder);
            builder.Property(m => m.photo)
                 .HasMaxLength(500);
        }

    }
}
