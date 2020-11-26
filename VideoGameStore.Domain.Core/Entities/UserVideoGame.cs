using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameStore.Domain.Core.Entities
{
    public class UserVideoGame
    {
        public int Id { get; set; }
        
        public int VideoGameId { get; set; }

        public VideoGame VideoGame { get; set; }

        public User User { get; set; }

    }
}
