using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HashtagAPI.Models;

namespace HashtagAPI.Controllers
{
    public class DbInitializer
    {
        public static void Initialize(HashtagContext context)
        {
            if (context.TweetLog.Any())
            {
                return; // deb has been seeded
            }
            // else this is where I'll put my logic to read from my spreadsheet and fill my database
        }
    }
}
