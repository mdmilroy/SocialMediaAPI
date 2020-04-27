using Data;
using Models;
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
        private readonly int _commentId;

        public ReplyService(Guid userId)
        {
            _userId = userId;
        }

        public ReplyService(int commentId)
        {
            _commentId = commentId;
        }

        public bool ReplyOnComment(PostReplyToComment model)
        {
            var replyToCreate = new Reply()
            {
                ReplyId = model.ReplyId,
                Text = model.Text,
                Author = model.Author,
                CommentId = model.CommentId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Replies.Add(replyToCreate);
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
                        .Single(e => e.ReplyId == model.PostId && e.UserId == _userId);

                replyToUpdate.Text = model.Text;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteReply(int replyId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var replyToDelete =
                    ctx
                        .Replies
                        .Single(e => e.ReplyId == replyId && e.Author.UserId == _userId);

                ctx.Comments.Remove(replyToDelete);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}