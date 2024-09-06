using ASP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.DataAccess.Configuration
{
    public class RecipeConfiguratiion : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.Property(x => x.TitleRecipe).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(800);
            builder.Property(x => x.TotalKcal).IsRequired().HasMaxLength(50);

            builder.HasMany(x => x.RecipeFoods).WithOne(x => x.Recipe).HasForeignKey(x => x.IdRecipe).OnDelete(DeleteBehavior.Restrict);
     
            builder.HasMany(x => x.RecipeCategories).WithOne(x => x.Recipe).HasForeignKey(x => x.IdRecipe).OnDelete(DeleteBehavior.Restrict);
            //builder.HasMany(x=>x.Comments).WithOne(x=>x.Recipe).HasForeignKey(x => x.IdRecipe).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.Comments).WithOne(x => x.Recipe).HasForeignKey(x => x.IdRecipe).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.UserRecipeReactions).WithOne(x => x.Recipe).HasForeignKey(x => x.IdRecipe).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Rates).WithOne(x => x.Recipe).HasForeignKey(x => x.IdRecipe).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
