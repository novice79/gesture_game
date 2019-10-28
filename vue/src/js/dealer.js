

export default {
    "帮助": function (result, points) {
        //?
        vm.$router.push('help');
    },
    "聊天": function (result, points) {
        //c
        vm.$router.push('help');    
    },
    "商品": function (result, points) {
        //p
        vm.$router.push('help');
    },
    "购买": function (result, points) {
        //b

        
    },
    "订单": function (result, points) {
        //o
        gameInstance.SendMessage('Player', 'startWhirlwind');
    },
    "通知": function (result, points) {
        //n
        vm.$router.push('gestures');
    },
    "手势": function (result, points) {
        //g
        vm.$router.push('gestures');
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
    //ch stand for canvas handler
    touchstart:function( ch ) {

    },
    touchend:function( ch ) {
        ch.clear()
    }
}