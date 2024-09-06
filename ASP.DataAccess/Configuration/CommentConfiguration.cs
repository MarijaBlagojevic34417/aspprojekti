
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
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(x => x.Text).IsRequired();

            builder.HasIndex(x => x.IdParentComment);

            builder.HasMany(x => x.ChildrenComments).WithOne(x => x.ParentComment)
                .HasForeignKey(x => x.IdParentComment).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.UserCommentReactions).WithOne(x => x.Comment)
              .HasForeignKey(x => x.IdComment).OnDelete(DeleteBehavior.Restrict);



        }
    }
}
