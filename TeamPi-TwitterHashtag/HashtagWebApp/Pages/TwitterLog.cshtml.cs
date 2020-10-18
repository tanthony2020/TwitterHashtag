using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HashtagWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;

namespace HashtagWebApp.Pages
{
    [BindProperties(SupportsGet =  true)]
    public class TwitterLogModel : PageModel
    {
        private static IConfiguration _config = null;
        public TwitterLogModel(IConfiguration configuration)
        {
            _config = configuration;
        }
        [ViewData]
        public DisplayTweets Tweets { get; set; }
        public void OnGet()
        {
            var client = new RestClient { BaseUrl = new Uri(_config.GetSection("BaseAPI").Value) };
            var request = new RestRequest { Resource = "GetTweets" };

            var response = client.Execute(request);
            if (response.IsSuccessful)
            {
                var results = response.Content;
                // convert to Json Object
                Tweets = JsonConvert.DeserializeObject<DisplayTweets>(results);
                //var tweetLog = new Tweets { tweets = tweets };
                
            }

            ViewData["tweets"] = Tweets;
        }
    }
}
