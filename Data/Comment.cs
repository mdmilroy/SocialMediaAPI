using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        
        public string CommentText { get; set; }
        public string Author { get; set; }
        public User User { get; set; }


        [ForeignKey("CommentedPost")]
        public int PostId { get; set; }
        public virtual Post CommentedPost { get; set; }
    }
}