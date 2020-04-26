using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        public User user { get; set; }

        public Post CommentedPost { get; set; }
    }
}