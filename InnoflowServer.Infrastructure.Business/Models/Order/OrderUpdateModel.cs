using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameStore.Domain.Core.Models.Order
{
    public class OrderUpdateModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public DateTime DateTime { get; set; }
    }
}
