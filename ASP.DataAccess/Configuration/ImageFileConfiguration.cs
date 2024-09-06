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
    public class ImageFileConfiguration : IEntityTypeConfiguration<ImageFile>
    {
        public void Configure(EntityTypeBuilder<ImageFile> builder)
        {
            builder.Property(x => x.Path).IsRequired().HasMaxLength(250);

            builder.HasMany(x => x.Recipes).WithOne(x => x.ImageFiles).HasForeignKey(x => x.IdImageFile).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Users).WithOne(x => x.ImageFiles).HasForeignKey(x => x.IdImageFile).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
