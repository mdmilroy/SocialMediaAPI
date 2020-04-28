using Microsoft.AspNet.Identity;
using Models.Reply;
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
    [RoutePrefix("api/replies")]
    public class ReplyController : ApiController
    {
        private ReplyService CreateReplyService()
        {
            var authorId = Guid.Parse(User.Identity.GetUserId());
            var authorName = User.Identity.Name;
            var replyService = new ReplyService(authorId, authorName);
            return replyService;
        }

        [HttpPost]
        public IHttpActionResult Post(PostReply replyToPost)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateReplyService();

            if (!service.ReplyOnComment(replyToPost))
                return InternalServerError();

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put(EditAReply replyToEdit)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateReplyService();

            if (!service.UpdateReply(replyToEdit))
                return InternalServerError();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateReplyService();

            if (!service.DeleteReply(id))
                return InternalServerError();

            return Ok();

        }

    }
}
