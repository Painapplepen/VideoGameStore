using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameStore.Domain.Core.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public int VideoGameId { get; set; }
    }
}
