using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameStore.Domain.Core.Entities
{
    public class User : IdentityUser
    {
        public List<Comment> Comments { get; set; }

        public List<UserVideoGame> UserVideoGames { get; set; }

        public List<UserOrder> UserOrders { get; set; }
    }
}
