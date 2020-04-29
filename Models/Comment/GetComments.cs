using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Comment
{
    public class GetComments
    {
        public int PostId { get; set; }
        public string PostTitle { get; set; }
        public string CommentText { get; set; }
        public string Author { get; set; }
        public int CommentId { get; set; }
    }
}
