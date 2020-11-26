using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameStore.Domain.Core.Entities
{
    public class VideoGame
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public int Cost { get; set; }

        public int Year { get; set; }

        public int Rating { get; set; }

        public int GenreId { get; set; }
        
        public int CompanyId { get; set; }

        public int OrderId { get; set; }

        public GameGenre GameGenre { get; set; }

        public Company Company { get; set; }

        public Order Order { get; set; }

        public DateTime DateTime { get; set; }

        public List<Comment> Comments { get; set; }

        public List<UserVideoGame> UserVideoGames { get; set; }
    }
}
