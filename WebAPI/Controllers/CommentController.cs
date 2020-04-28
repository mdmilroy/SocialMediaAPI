using Microsoft.AspNet.Identity;
using Models.Comment;
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
        private CommentService CreateCommentService()
        {
            var authorId = Guid.Parse(User.Identity.GetUserId());
            var authorName = User.Identity.Name;
            var commentService = new CommentService(authorId, authorName);
            return commentService;
        }
        
        [HttpGet]
        [Route("{postId}")]
        public IHttpActionResult Get(int id)
        {
            CommentService commentService = CreateCommentService();
            var comments = commentService.GetComments(id);
            return Ok(comments);
        }

        [HttpPost]
        public IHttpActionResult Post(PostComment comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCommentService();

            if (!service.CommentOnPost(comment))
                return InternalServerError();

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put(EditAComment commentToEdit)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCommentService();

            if (!service.UpdateComment(commentToEdit))
                return InternalServerError();

            return Ok();
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
