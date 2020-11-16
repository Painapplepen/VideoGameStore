using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameStore.Domain.Core.Models.VideoGame
{
    public class VideoGameCreateModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(15, ErrorMessage = "Max length 15")]
        public string Name { get; set; }

        [Required]
        [MaxLength(15, ErrorMessage = "Max length 15")]
        public string Type { get; set; }

        [Required]
        public int Cost { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public int Rating { get; set; }

        [Required]
        public int GenreId { get; set; }

        [Required]
        public int CompanyId { get; set; }

        [Required]
        public int OrderId { get; set; }
    }
}
