using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PostLikeToPost
    {
        [Required]
        public Post LikedPost { get; set; }
        public User Liker { get; set; }
    }
}
