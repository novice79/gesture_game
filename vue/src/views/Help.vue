<template>
  <div class="help">
    <header>
        <div class="left" @click="$router.go(-1)">&larr;</div>
        <h1 class="title">使用说明</h1>
    </header>

    <div class="content">
      <div>
        <h2>操作</h2>
        <p>操作都是在屏幕上，以划动手势完成。
          下面说的划哪个字母，只是跟那个字母<i>近似的手势</i>，每个人书写的习惯不同可能会有误差。
          可以打开手势管理界面自定义习惯的手势操作。</p>
        <h3>人物移动</h3>
        <p>用手指在屏幕上滑动即可控制角色移动，移动的方向与滑动方向一致。点击自身停止移动</p>
        <h3>选择玩家</h3>
        <p>点击玩家角色以选择玩家，被选中的玩家头像会出现在屏幕上方。然后点击玩家头像则会显示玩家信息</p>
        <h3>聊天</h3>
        <p>在屏幕上划个c（for chat, 默认手势）打开聊天界面。如果当前已选中玩家则对玩家私聊，否则就对所有玩家广播</p>
        <h3>售卖</h3>
        <p>在屏幕上划个p（for product, 默认手势）打开商品管理界面。在此可以添加商品名称、描述、图片、价格。
          玩家的付款先打入智慧旅游账户，买方确认收货后，卖方5个工作日内会收到微信红包，包含售卖的金额（扣除千分之6手续费）。
          如果买家选择开电子发票，还需额外扣除千分之1费用。</p>
        <h3>购买</h3>
        <p>有商品销售的玩家头上会有个“卖”字，点击选中此玩家后，划b（for buy，默认手势），打开该玩家的产品页面</p>
        <h3>订单</h3>
        <p>在屏幕上划个o（for order, 默认手势）打开订单界面。在此可以查看售卖的订单记录</p>
        <h3>系统通知</h3>
        <p>在屏幕上划个n（for notification, 默认手势）打开系统通知界面。在此可以查看系统通知记录，比如买家支付成功、已发货、已确认收货等</p>
        <h3>手势设置</h3>
        <p>在屏幕上划个g（for gestures, 默认手势）打开手势设置界面。在此可以更改默认手势。编辑手势时需一笔划完，中途不可抬起手指，可以是任意字母、符号、汉字……</p>
        <h3>帮助</h3>
        <p>在屏幕上划个h（for help, 默认手势）打开此帮助界面。在此界面点以下按钮可以跳转到其它各功能界面</p>
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
h3 {
  margin: 40px 0 0;
}

</style>
