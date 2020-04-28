using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class Like
    {
        public Post LikedPost { get; set; }
        public User Liker { get; set; }
    }
}