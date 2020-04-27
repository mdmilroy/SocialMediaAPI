using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PostReplyToComment
    {
        [Required]
        public int CommentId { get; set; }
        public int ReplyId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(140, ErrorMessage = "There are too many characters in this field.")]
        public string Text { get; set; }

        [Required]
        [Display(Name = "Created By")]
        public User Author { get; set; }

    }
}
