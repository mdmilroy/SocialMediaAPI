using Microsoft.AspNet.Identity;
using Models;
using Models.Posts;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Comments")]
    public class CommentController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            CommentService commentService = CreateCommentService();
            var posts = commentService.GetPostComments();
            return Ok(posts);
        }

        [HttpPost]
        public IHttpActionResult Post(PostCommentOnPost comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCommentService();

            if (!service.CommentOnPost(comment))
                return InternalServerError();

            return Ok();
        }

        private CommentService CreateCommentService()
        {
            var authorId = Guid.Parse(User.Identity.GetUserId());
            var commentService = new CommentService(authorId);
            return commentService;
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateCommentService();

            if (!service.DeleteComment(id))
                return InternalServerError();

            return Ok();

        }
    }
}
