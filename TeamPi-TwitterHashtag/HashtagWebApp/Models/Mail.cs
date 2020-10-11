using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HashtagWebApp.Models
{
    public class Mail
    {
        public string Client { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public NetworkCredentials NetworkCredentials { get; set; }
    }
    public class NetworkCredentials
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
