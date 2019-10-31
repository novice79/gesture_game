<template>
  <div class="help">
    <header>
        <div class="left" @click="$router.go(-1)">&larr;</div>
        使用说明
    </header>
    <div class="content">
      <div>
        <h3>人物移动</h3>
        <p>用手指在屏幕上滑动即可控制角色移动，移动的方向与滑动方向一致。移动的时间与划线的长度成比例，画的线越长奔跑的越久。</p>
        <h3>旋转摄像头</h3>
        <p>用两个手指控制摄像机自由旋转，一个手指按住屏幕不放，另一个手指控制摄像机旋转方向。其后再用一个手指操作角色，摄像机会自动变为跟随模式。</p>
        <h3>技能施放</h3>
        <p>在主屏幕上画手势施放对应的技能，比如画个O施放【剑刃风暴】。每个技能对应的手势请参考“手势设置”界面。每个手势都可自行修改。就像定义技能快捷键一样。
          <br>
          除了【剑刃风暴】，其它技能都必须在站立姿态下才能施放。
        </p>
        <h3>打开其它界面</h3>
        <p>可以用以下按钮跳转过去。也可在主屏幕画手势完成。比如画个h打开“帮助界面”，画g打开“手势设置”界面。当然这些手势也可修改，同上。</p>
        <hr>
        P.S.每个手势请用连笔画成，中间不能中断。
        <hr>
        <button @click="$router.push('/gestures')">手势设置</button>
        
      </div>
    </div>
  </div>
</template>
<script>
export default {
  name: 'Help',
  
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.content {
  background-color: lightgray;
  text-align: left;
}
button{
  margin: 1em 0.5em;
  font-size: 1.5rem;
  border-radius: 0.7em;
  width: 90%;
  background-color: lightskyblue;
}
.content > div > h3:not(:first-child){
  margin-top: 0.7em;
}
</style>
