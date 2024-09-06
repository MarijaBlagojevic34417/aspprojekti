using ASP.Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.DataAccess.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
        {
            //regularno
            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(100);
            builder.Property(x => x.IdImageFile).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Username).IsRequired().HasMaxLength(100);
            //index
            builder.HasIndex(x => x.FirstName);
            builder.HasIndex(x => x.LastName);
            builder.HasIndex(x => x.Username).IsUnique();
            builder.HasIndex(x => x.Email).IsUnique();

            //veze
           
            builder.HasMany(x => x.Comments).WithOne(x => x.User).HasForeignKey(x => x.IdUser).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Rates).WithOne(x => x.User).HasForeignKey(x => x.IdUser).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.UserUseCases).WithOne(x => x.User).HasForeignKey(x => x.IdUser).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Recipes).WithOne(x => x.User).HasForeignKey(x => x.IdUser).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.UserCommentReactions).WithOne(x => x.User).HasForeignKey(x => x.IdUser).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.UserRecipeReaction).WithOne(x => x.User).HasForeignKey(x => x.IdUser).OnDelete(DeleteBehavior.Restrict);


        }
    }
}
