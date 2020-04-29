using Data;
using Models.Comment;
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
        private readonly string _userName;
        public CommentService(Guid userId, string userName)
        {
            _userId = userId;
            _userName = userName;
        }

        public bool CommentOnPost(PostComment model)
        {
            var commentToPost = new Comment()
            {
                PostId = model.PostId,
                CommentText = model.CommentText,
                Author = _userName,
                UserId = _userId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(commentToPost);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GetComments> GetComments(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Comments
                    .Where(e => e.PostId == id && e.UserId == _userId)
                    .Select(
                        e =>
                        new GetComments
                        {
                            PostId = e.CommentedPost.PostId,
                            PostTitle = e.CommentedPost.PostTitle,
                            CommentId = e.CommentId,
                            CommentText = e.CommentText,
                            Author = e.Author
                        });
                return query.ToArray();
            }
        }

        public bool UpdateComment(EditAComment model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var commentToUpdate =
                    ctx
                    .Comments
                    .Single(e => e.CommentId == model.CommentId && e.UserId == _userId);
                commentToUpdate.CommentText = model.CommentText;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteComment(int commentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var commentToDelete =
                    ctx
                    .Comments
                    .Single(e => e.CommentId == commentId && e.UserId == _userId);

                ctx.Comments.Remove(commentToDelete);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
