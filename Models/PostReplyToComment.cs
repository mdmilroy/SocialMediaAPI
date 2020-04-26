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
        public User Author { get; set; }

    }
}
