using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameStore.Domain.Core.DTO
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Com { get; set; }
        public int UserId { get; set; }
    }
}
