using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace HashtagWebApp.Pages.Project
{
    public class TwitterLogModel : PageModel
    {
        private static IConfiguration _config = null;
        public TwitterLogModel(IConfiguration configuration)
        {
            _config = configuration;
        }
        public void OnGet()
        {
            // call api and get list of tweets
            var client = new RestClient {BaseUrl = new Uri(_config.GetSection("BaseAPI").Value)};
            var request = new RestRequest();
            request.Resource = "GetTweets";

            var response = client.Execute(request);


        }
    }
}
