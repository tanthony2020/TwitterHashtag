using System;
using System.Collections.Generic;

namespace HashtagAPI.Models
{
    public partial class IncomingTweet
    {
        public string TweetId { get; set; }
        public string Tweet { get; set; }
        public string TwitterHandle { get; set; }
        //public string TweetDateTime { get; set; }
        public string Party { get; set; }
    }
}
