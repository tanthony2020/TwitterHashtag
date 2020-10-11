using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using HashtagAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
        public ActionResult AddTweet(IncomingTweet tweetToAdd)
        {
            //var tweetToAdd = JsonConvert.DeserializeObject<IncomingTweet>(jsonResult);
            //var tweetToAdd = new IncomingTweet();
            
            var tweet = new TweetLog
            {
                TweetId = tweetToAdd.TweetId, Party = tweetToAdd.Party, Tweet = tweetToAdd.Tweet, TwitterHandle = tweetToAdd.TwitterHandle
            };

            var cultureInfo = new CultureInfo("en-US");
            var date = DateTime.Now;
           

            tweet.TweetDateTime = date;
            
            _context.TweetLog.Add(tweet);
            _context.SaveChanges();
            return Ok();

        }
    }
}
