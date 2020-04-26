using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CommentService
    {
        private readonly Guid _userId;
        private readonly Post _postId;

        public CommentService(Guid userId)
        {
            _userId = userId;
        }

        public CommentService(Post postId)
        {
            _postId = postId;
        }

        public bool CommentOnPost(PostCommentOnPost model)
        {
            var commentToCreate = new Comment()
            {
                CommentId = model.CommentId,
                Text = model.Text,
                Author = model.Author,
                PostId = model.PostId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(commentToCreate);
                return ctx.SaveChanges() == 1;
            }
        }


    }
}
