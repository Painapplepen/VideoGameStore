using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Domain.Core.Entities;

namespace VideoGameStore.Infrastructure.Data.Configurations
{
    public class VideoGameConfiguration : IEntityTypeConfiguration<VideoGame>
    {
        public void Configure(EntityTypeBuilder<VideoGame> builder)
        {
            builder.Property(o => o.CompanyId).
                IsRequired();

            builder.Property(o => o.OrderId).
                IsRequired();

            builder.Property(o => o.Type).
                IsRequired().
                HasMaxLength(5);

            builder.Property(o => o.Name).
                IsRequired().
                HasMaxLength(20);

            builder.Property(o => o.Cost).
                IsRequired();

            builder.Property(o => o.Year).
                IsRequired();
        }
    }
}
