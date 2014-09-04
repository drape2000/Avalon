
var pomoObjectApp = function() {
    var timerObjects;
    var today = moment().format('dddd');

    if (today === 'Tuesday') {
        timerObjects = getSchedule('tuesday');
    } else if (today === 'Friday') {
        timerObjects = getSchedule('friday');
    } else if (today === 'Monday' || today === 'Wednesday' || today === 'Thursday') {
        timerObjects = getSchedule('standard');
    }

    var sound = new Audio(getSound());

    window.setInterval(function () {
        

        for (var i = 0; i < timerObjects.length; i++) {
            var isCurrent = moment().startOf('day').add('hours', timerObjects[i].startTimeHour).add('minutes', timerObjects[i].startTimeMinute) < moment();
            if (isCurrent === false) {
                var timing = moment().startOf('day').add('hours', timerObjects[i].startTimeHour).add('minutes', timerObjects[i].startTimeMinute).subtract(moment()).format("mm:ss");
                if (moment().hours() < 17) {
                    document.getElementById('timer').innerHTML = timing;
                } else {
                    document.getElementById('timer').innerHTML = '';
                }
                var currentColor = document.body.style.backgroundColor;
                var nextColor = timerObjects[i - 1].colorBackground;
                if (currentColor !== nextColor) {
                    sound.play();
                }
                document.body.style.backgroundColor = nextColor;
                document.getElementById('placeForTheTime').innerHTML = timerObjects[i - 1].statusName;
                
                break;
            }
        }
    },100);
    
};

var getSound = function () {
    var sound;

    var sounds = ['Sound/beep-01a.mp3', 'Sound/beep-09.mp3', 'Sound/train-whistle-01.mp3'];

    var random = Math.floor(Math.random() * sounds.length);
    sound = sounds[random];

    return sound;

}

pomoObjectApp();


