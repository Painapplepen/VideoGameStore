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
    public class GameGenreConfiguration : IEntityTypeConfiguration<GameGenre>
    {
        public void Configure(EntityTypeBuilder<GameGenre> builder)
        {
            //builder.HasMany(o => o.VideoGames).
            //    WithOne(o => o.Genre);

            builder.Property(o => o.Name).
                IsRequired().
                HasMaxLength(15);
        }
    }
}
