using System;
using System.Collections.Generic;

namespace HashtagWebApp.Models
{
    public partial class TweetLog
    {
        public string TweetId { get; set; }
        public string Tweet { get; set; }
        public string TwitterHandle { get; set; }
        public DateTime TweetDateTime { get; set; }
        public string Party { get; set; }
    }
}
