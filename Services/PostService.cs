using Data;
using Models;
using Models.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PostService
    {
        private readonly Guid _userId;
        public PostService(Guid userId)
        {
            _userId = userId;
        }


        public bool CreatePost(PostAPost model)
        {
            var postToCreate = new Post()
            {
                UserId = _userId,
                Title = model.Title,
                Text = model.Text,


            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(postToCreate);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GetPosts> GetPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Posts
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                                new GetPosts
                                {
                                    PostId = e.PostId,
                                    Title = e.Title,
                                    Author = e.Author.Name
                                }
                        );

                return query.ToArray();
            }
        }

        public PostDetail GetPostById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Posts
                        .Single(e => e.PostId == id && e.UserId == _userId);
                return
                    new PostDetail
                    {
                        PostId = entity.PostId,
                        Title = entity.Title,
                        Text = entity.Text,
                        Author = entity.Author.Name,
                        Likes = entity.Likes
                    };
            }
        }

        public bool UpdatePost(EditAPost model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var postToUpdate =
                    ctx
                        .Posts
                        .Single(e => e.PostId == model.PostId && e.UserId == _userId);

                postToUpdate.Title = model.Title;
                postToUpdate.Text = model.Text;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePost(int postId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var postToDelete =
                    ctx
                        .Posts
                        .Single(e => e.PostId == postId && e.UserId == _userId);

                ctx.Posts.Remove(postToDelete);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}