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
    public class UserRecipeReactionConfiguration : IEntityTypeConfiguration<UserRecipeReaction>
    {
        public void Configure(EntityTypeBuilder<UserRecipeReaction> builder)
        {
            builder.Property(x => x.IdRecipe).IsRequired().HasMaxLength(150);
            builder.Property(x => x.IdUser).IsRequired().HasMaxLength(150);
            builder.Property(x => x.IdReaction).IsRequired().HasMaxLength(150);
        }
    }
}
