using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        public string PostTitle { get; set; }
        
        public string PostText { get; set; }
        public int Likes { get; set; }

        [ForeignKey("Author")]
        public Guid UserId { get; set; }
        public virtual User Author { get; set; }
    }
}