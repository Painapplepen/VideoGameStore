using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameStore.Domain.Core.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Com { get; set; }
        public VideoGame VideoGame { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
