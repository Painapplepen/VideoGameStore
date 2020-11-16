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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasOne(o => o.VideoGame).
                WithOne(o => o.Order).
                HasForeignKey<Order>(o => o.VideoGameId);

            builder.Property(o => o.VideoGameId).
                IsRequired();
        }
    }
}
