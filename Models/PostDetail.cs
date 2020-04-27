using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Posts
{
    public class PostDetail
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        [Display(Name = "Created By")]
        public string Author { get; set; }
        public int Likes { get; set; }
    }
}
