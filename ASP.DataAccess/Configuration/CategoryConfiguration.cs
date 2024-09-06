
using ASP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.DataAccess.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.NameCategory).IsRequired().HasMaxLength(50);
            builder.HasIndex(x => x.NameCategory).IsUnique();

            builder.HasMany(x => x.RecipeCategories)
                .WithOne(x => x.Category).HasForeignKey(x => x.IdCategory).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
