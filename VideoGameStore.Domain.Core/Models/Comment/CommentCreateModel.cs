using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameStore.Domain.Core.Models.Comment
{
    public class CommentCreateModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(1000, ErrorMessage = "Max length 1000")]
        public string Com { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}
