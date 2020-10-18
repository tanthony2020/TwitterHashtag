using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HashtagWebApp.Models
{
    public class DisplayTweets
    {
        public List<TweetLog> Tweets { get; set; }
        public int RepublicanTweets { get; set; }
        public int DemocratTweets { get; set; }
    }
}
