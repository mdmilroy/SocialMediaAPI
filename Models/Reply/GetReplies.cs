using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Reply
{
    public class GetReplies
    {
        public string ReplyText { get; set; }
        public string Author { get; set; }
        public int CommentId { get; set; }
        public int ReplyId { get; set; }
    }
}
