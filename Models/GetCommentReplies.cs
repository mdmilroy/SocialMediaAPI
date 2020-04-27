using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class GetCommentReplies
    {
        public int CommentId { get; set; }
        public Comment ReplyComment { get; set; }
    }
}
