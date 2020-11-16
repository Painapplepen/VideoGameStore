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
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            //builder.HasOne(o => o.VideoGame).
            //    WithMany(o => o.Comments);

            //builder.HasOne(o => o.User).
            //    WithMany(o => o.Comments);

            builder.Property(o => o.Com).
                IsRequired().
                HasMaxLength(15);

            builder.Property(o => o.UserId).
                IsRequired();
        }
    }
}
