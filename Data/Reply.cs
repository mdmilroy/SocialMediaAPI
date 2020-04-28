using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class Reply/* : Comment*/
    {        
        [Key]
        public int ReplyId { get; set; }

        public string ReplyText { get; set; }
        public string Author { get; set; }
        public Guid UserId { get; set; }


        [ForeignKey("RepliedComment")]
        public int CommentId { get; set; }
        public virtual Comment RepliedComment { get; set; }
        //public Comment ReplyComment { get; set; }
    }
}