using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameStore.Domain.Core.Models.Company
{
    public class CompanyCreateModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(15, ErrorMessage = "Max length 15")]
        public string Name { get; set; }

        [Required]
        [MaxLength(15, ErrorMessage = "Max length 15")]
        public string Location { get; set; }
    }
}
