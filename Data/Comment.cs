using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public string Text { get; set; }
        public User Author { get; set; }

        [ForeignKey("CommentedPost")]
        public int PostId { get; set; }
        public virtual Post CommentedPost { get; set; }

        public int Likes { get; set; }
    }
}