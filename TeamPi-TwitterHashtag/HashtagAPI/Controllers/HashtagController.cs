using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HashtagAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HashtagAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HashtagController : ControllerBase
    {
        private readonly HashtagContext _context;

        public HashtagController(HashtagContext context)
        {
            _context = context;
        }
        // GET: api/<HashtagController>
        [HttpGet]
        public string Get()
        {
            return "Hashtag API Started";
        }

        [Route("GetTweets")]
        public ActionResult GetTweets()
        {
            var tweetLog = _context.TweetLog.FirstOrDefault();
            return Ok(tweetLog);
        }

        [Route("AddTweet")]
        public ActionResult AddTweet()
        {
            var headers = Request.Headers;
            if (headers.TryGetValue("tweet", out var tweetValue))
            {
                var tweetToAdd = JsonConvert.DeserializeObject<TweetLog>(tweetValue);
                _context.TweetLog.Add(tweetToAdd);
            }
            else
            {
                return BadRequest("No tweet found in header");
            }

            return Ok();

        }
    }
}
