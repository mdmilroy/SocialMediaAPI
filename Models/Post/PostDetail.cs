using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Post
{
    public class PostDetail
    {
        public int PostId { get; set; }
        public string PostTitle { get; set; }
        public string PostText { get; set; }
        public string Author { get; set; }
        public int Likes { get; set; }
    }
}
