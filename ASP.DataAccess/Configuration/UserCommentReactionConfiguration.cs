using ASP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ASP.DataAccess.Configuration
{
    public class UserCommentReactionConfiguration : IEntityTypeConfiguration<UserCommentReaction>
    {
        public void Configure(EntityTypeBuilder<UserCommentReaction> builder)
        {
            builder.Property(x => x.IdComment).IsRequired().HasMaxLength(150);
            builder.Property(x => x.IdUser).IsRequired().HasMaxLength(150);
            builder.Property(x => x.IdReaction).IsRequired().HasMaxLength(150);
        }
    }
}
