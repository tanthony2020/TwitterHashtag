var Cylon = require('cylon');
var Gpio = require('onoff').Gpio;
var Twitter = require('twitter');
const dotenv = require('dotenv');

dotenv.config();
var LED = new Gpio(24, 'out');
var client = new Twitter({
    consumer_key: process.env.CONSUMER_KEY,
    consumer_secret: process.env.CONSUMER_SECRET,
    access_token_key: process.env.ACCESS_TOKEN_KEY,
    access_token_secret: process.env.ACCESS_TOKEN_SECRET
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
    client.stream('statuses/filter', { follow: "Hashtag" }, function (stream) {
        stream.on('data', function (data) {


        });
    });
}
