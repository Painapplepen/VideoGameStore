using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Domain.Core.Models;

namespace VideoGameStore.Infrastructure.Data.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            //builder.HasMany(o => o.VideoGames).
            //    WithOne(o => o.Company);

            builder.Property(o => o.Name).
                IsRequired().
                HasMaxLength(15);
        }
    }
}
