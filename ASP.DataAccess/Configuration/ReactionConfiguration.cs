using ASP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.DataAccess.Configuration
{
    public class ReactionConfiguration : IEntityTypeConfiguration<Reaction>
    {
        public void Configure(EntityTypeBuilder<Reaction> builder)
        {
            builder.Property(x => x.NameReaction).IsRequired().HasMaxLength(50);
            builder.HasIndex(x => x.NameReaction).IsUnique();

          builder.HasMany(x => x.UserCommentReactions).WithOne(x => x.Reaction).HasForeignKey(x => x.IdReaction).OnDelete(DeleteBehavior.Restrict);
          builder.HasMany(x => x.UserRecipeReactions).WithOne(x => x.Reaction).HasForeignKey(x => x.IdReaction).OnDelete(DeleteBehavior.Restrict);
           
        
        }
    }
}
