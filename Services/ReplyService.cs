using Data;
using Models.Reply;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ReplyService
    {
        private readonly Guid _userId;
        private readonly string _userName;

        public ReplyService(Guid userId, string userName)
        {
            _userId = userId;
            _userName = userName;
        }

        public bool ReplyOnComment(PostReply model)
        {
            var replyToPost = new Reply()
            {
                CommentText = model.ReplyText,
                Author = _userName,
                CommentId = model.CommentId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Replies.Add(replyToPost);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdateReply(EditAReply model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var replyToUpdate =
                    ctx
                        .Replies
                        .Single(e => e.ReplyId == model.ReplyId && e.UserId == _userId);

                replyToUpdate.CommentText = model.ReplyText;

                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GetReplies> GetReplies(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Replies
                    .Where(e => e.ReplyId == id && e.UserId == _userId)
                    .Select(
                        e =>
                        new GetReplies
                        {
                            ReplyText = e.CommentText,
                            Author = e.Author
                        });
                return query.ToArray();
            }
        }

        public bool DeleteReply(int replyId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var replyToDelete =
                    ctx
                        .Replies
                        .Single(e => e.ReplyId == replyId && e.UserId == _userId);

                ctx.Replies.Remove(replyToDelete);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
