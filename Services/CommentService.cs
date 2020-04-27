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
        private readonly int _postId;
        private readonly int _commentId;

        public CommentService(Guid userId)
        {
            _userId = userId;
        }

        public CommentService(int postId)
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

        public IEnumerable<GetPostComments> GetPostComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Posts
                    .Where(e => e.PostId == _postId)
                    .Select(
                        e =>
                            new GetPostComments
                            {
                                PostId = e.PostId,
                                Title = e.Title
                            });
                return query.ToArray();
            }
        }

        public IEnumerable<GetCommentReplies> GetCommentReplies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Replies
                    .Where(e => e.ReplyComment.CommentId == _commentId)
                    .Select(
                        e =>
                            new GetCommentReplies
                            {
                                CommentId = e.CommentId,
                                ReplyComment = e.ReplyComment
                            });
                return query.ToArray();
            }
        }

        public bool DeleteComment(int commentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var commentToDelete =
                    ctx
                        .Comments
                        .Single(e => e.CommentId == commentId && e.Author.UserId == _userId);

                ctx.Comments.Remove(commentToDelete);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
