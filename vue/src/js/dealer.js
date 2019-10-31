

export default {
    "帮助": function (result, points) {
        //h
        vm.$router.push('help');
    },
    "手势": function (result, points) {
        //g
        vm.$router.push('gestures');
    },
    "流星打击": function (result, points) {
        //S
        gameInstance.SendMessage('Player', 'startDHMeteorStrike');
    },
    "剑刃风暴": function (result, points) {
        //o
        // console.log('startWhirlwind')
        gameInstance.SendMessage('Player', 'startWhirlwind');
    },
    "冥想": function (result, points) {
        //c
        gameInstance.SendMessage('Player', 'startMeditate');
    },
    "风暴打击": function (result, points) {
        //v
        gameInstance.SendMessage('Player', 'startStormstrike');     
    },
    "猛虎掌": function (result, points) {
        //z
        gameInstance.SendMessage('Player', 'startPalmStrike'); 
    },
    "旭日东升踢": function (result, points) {
        //r
        gameInstance.SendMessage('Player', 'startRisingSunKick'); 
    },
    "火焰之息": function (result, points) {
        //b
        gameInstance.SendMessage('Player', 'startBreathOfFire'); 
    },
    "鼓掌": function (result, points) {
        //a
        gameInstance.SendMessage('Player', 'startEmoteApplaud'); 
    },
    "翔龙在天": function (result, points) {
        //k
        gameInstance.SendMessage('Player', 'startFlyingKick'); 
    },
    "怒雷破": function (result, points) {
        //f
        gameInstance.SendMessage('Player', 'startThousandFists'); 
    },
    no_recognize : points =>{
        console.log('in no_recognize')
        if( !points[points.length - 1].X ){
            points.pop()
        }
        const p_begin = points[0],
              p_end = points[points.length - 1],
              h = document.body.clientHeight; //or window.innerHeight?
        const data = `${p_begin.X},${h - p_begin.Y},${p_end.X},${h - p_end.Y}`;
        gameInstance.SendMessage('Player', 'Go', data);
    },
    few_touch : (points, e) =>{
        // console.log('in few_touch', e)

    },
    touchmove: (dx, dy, is_multi)=>{
        if(is_multi){
            // console.log(`touchmove(multi), dx=${dx}; dy=${dy}`)
            // can only send one parameter, a string or a number
            // use z for sensitivity
            gameInstance.SendMessage('MainCamera', 'RotateCam', JSON.stringify({x: dx, y: dy, z: 0.9}) );
        }
    },
    //ch stand for canvas handler
    touchstart: function( ch ) {
        gameInstance.SendMessage('MainCamera', 'FreeRotateCam', ch.is_multi? 1 : 0);
    },
    touchend: function( ch ) {
        gameInstance.SendMessage('MainCamera', 'FreeRotateCam', ch.is_multi? 1 : 0);
        ch.clear();
    }
}