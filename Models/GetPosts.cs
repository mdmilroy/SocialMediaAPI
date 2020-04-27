using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Posts
{
    public class GetPosts
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
    }
}
