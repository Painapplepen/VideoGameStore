using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameStore.Domain.Core.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public List<VideoGame> VideoGames { get; set; }
    }
}
