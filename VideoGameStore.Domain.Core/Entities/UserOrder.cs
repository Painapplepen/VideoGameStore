using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameStore.Domain.Core.Entities
{
    public class UserOrder
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
