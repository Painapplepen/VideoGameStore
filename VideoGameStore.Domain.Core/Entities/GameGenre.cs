using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameStore.Domain.Core.Entities
{
    public class GameGenre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<VideoGame> VideoGames { get; set; }
    }
}
