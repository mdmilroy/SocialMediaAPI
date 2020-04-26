using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        public User Author { get; set; }

        [ForeignKey("CommentedPost")]
        public int PostId { get; set; }
        public virtual Post CommentedPost { get; set; }

        public int Likes { get; set; }
    }
}