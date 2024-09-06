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
    public class FoodConfiguration : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            builder.Property(x => x.NameFood).IsRequired().HasMaxLength(50);
            builder.Property(x => x.KcalPer100gr).IsRequired().HasMaxLength(50);

            builder.HasIndex(x => x.NameFood).IsUnique();


            builder.HasMany(x => x.RecipeFoods).WithOne(x => x.Food).HasForeignKey(x => x.IdFood).OnDelete(DeleteBehavior.Restrict);




        }
    }
}
