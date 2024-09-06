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
    public class UseCaseLogConfiguration : IEntityTypeConfiguration<UseCaseLog>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Domain.Entities.UseCaseLog> builder)
        {
            builder.Property(x => x.Username).IsRequired().HasMaxLength(50);
            builder.Property(x => x.UseCaseName).IsRequired().HasMaxLength(50);

            builder.HasIndex(x => new { x.Username, x.UseCaseName, x.ExecutedAt })
                   .IncludeProperties(x => x.UseCaseData);
        }

       
    }
}
