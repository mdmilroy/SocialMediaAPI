using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class Reply : Comment
    {
        [Key]
        public int ReplyId { get; set; }
        public Comment ReplyComment { get; set; }

    }
}