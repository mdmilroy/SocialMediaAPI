using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        [ForeignKey("Author")]
        public Guid UserId { get; set; }
        public virtual User Author { get; set; }
        
        public int Likes { get; set; }
        public List<Comment> Comments { get; set; }
    }
}