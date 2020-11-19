/// <binding AfterBuild='deploy' />
var gulp = require('gulp');
var Candyman = require('candyman');

var candyman = new Candyman({
    targetDevices: [
        { devicename: 'pi@tammispi', hostname: 'tammispi' }
    ],
    projectName: 'TwitterHashtag',
    user: 'pi',
    password: 'Simba0405$',
    startFile: 'server.js'
});
gulp.task('deploy', function () {
    console.log('running deploy');
    return candyman.deploy();
});