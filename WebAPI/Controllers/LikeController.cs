using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/Likes")]
    public class LikeController : ApiController
    {
        private ApplicationDbContext _ctx = new ApplicationDbContext();
        [HttpPut]
        [Route("createLike")]
        public IHttpActionResult CreateLike([FromUri] int postToLikeId)
        {
            Post postToLike = _ctx.Posts.Find(postToLikeId);
            if (postToLike == null)
            {
                return BadRequest("The post you are looking for doesn't exist. Please use a real ID next time.");
            }
            postToLike.Likes += 1;
            _ctx.SaveChanges();
            return Ok();
        }
    }
}
