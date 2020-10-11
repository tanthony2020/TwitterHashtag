var Cylon = require("cylon");
var Gpio = require("onoff").Gpio;
var Twitter = require("twitter");
var dotenv = require("dotenv");
var axios = require("axios");

dotenv.config();
var redLed = new Gpio(14, "out");
var blueLed = new Gpio(4, "out");
var client = new Twitter({
    consumer_key: process.env.TWITTER_CONSUMER_KEY,
    consumer_secret: process.env.TWITTER_CONSUMER_SECRET,
    access_token_key: process.env.TWITTER_ACCESS_TOKEN_KEY,
    access_token_secret: process.env.TWITTER_ACCESS_TOKEN_SECRET
});

console.log("starting robot");
Cylon.robot({
    connections: {
        raspi: { adaptor: 'raspi' }
    },

    work: function (raspi) {
        console.log("Calling Hashtag");
        Hashtag();
    }
}).start();

function Hashtag() {
    // this will be changed to the api to follow a hashtag
    console.log("Monitoring #Republicans..............");
    // Republican
    client.stream('statuses/filter', { track: "#Republican" }, function (stream) {
        stream.on('data', function (data) {
            console.log("#Republican ");
            redLed.writeSync(1);
            setTimeout(function () { redLed.writeSync(0) }, 2000);

            PostToAPI(data.id, data.text, data.user.screen_name, "R");
        });
    });
    console.log("Monitoring #Democrats..............");
    // Democrat
    client.stream('statuses/filter', { track: "#Democrat" }, function (stream) {
        stream.on('data', function (data) {
            console.log("#Democrat ");
            blueLed.writeSync(1);
            setTimeout(function () { blueLed.writeSync(0) }, 2000);

            PostToAPI(data.id, data.text, data.user.screen_name, "D");
        });
    });
}
function PostToAPI(id, text, handle, party) {
    var tweet = {
        TweetId: id.toString(),
        Tweet: text,
        TwitterHandle: "@" + handle,
        Party: party
    };
    var config = {
        headers: {
            'Content-Type': 'application/json'
        }
    };


    axios.post('https://www.tamjomi.com/hashtagapi/api/Hashtag/AddTweet', tweet, config)
        .then((res) => {
            console.log(`Status: ${res.status}`);
            console.log('Body: ', res.data);
        }).catch((err) => {
            console.error(err);
        });

}