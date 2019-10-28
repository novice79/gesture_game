<template>
  <div class="home">
    <header>
      <div class="right" @click="$router.push('help')">&quest;</div>
      手势游戏
    </header>
    <div class="content">
      <div id="gameContainer"></div>
      <canvas class="recognize-area"></canvas>
    </div>
  </div>
</template>

<script>
// @ is an alias to /src
import dealer from "@/js/dealer";
import RegCanvas from "@/js/reg_canvas";

export default {
  name: 'home',
  created: function() {
    
  },
  beforeDestroy() {},
  destroyed() {

  },
  beforeRouteEnter (to, from, next) {
    // called before the route that renders this component is confirmed.
    // does NOT have access to `this` component instance,
    // because it has not been created yet when this guard is called!
    next(vm => {
      // access to component instance via `vm`
      if(window.gameInstance){
        gameInstance.SendMessage('Player', 'EnableCamera', 1);
      } 
    })     
  },
  beforeRouteLeave (to, from, next) {
    // called when the route that renders this component is about to
    // be navigated away from.
    // has access to `this` component instance.
    gameInstance.SendMessage('Player', 'EnableCamera', 0);
    next()
  },
  mounted() {
    window.gameInstance = UnityLoader.instantiate("gameContainer", "Build/dist.json");
    const canvas = document.querySelector(".recognize-area");   
    this.reg_canvas = new RegCanvas(canvas, dealer);
    this.setDimensions();
    $(window).on( 'resize', this.setDimensions.bind(this));
    console.log('Home page mounted')
  },
  data() {
    return {
      sub: ""
    };
  },
  computed: {
    sub_title() {
      return this.sub ? `(${this.sub})` : "";
    }
  },
  methods: {
    setDimensions() {
      const canvas = document.querySelector(".recognize-area");
      const rect = canvas.parentNode.getBoundingClientRect();
      canvas.width = rect.width;
      canvas.height = rect.height;
      console.log( `setDimensions(), rect.width=${rect.width}; rect.height=${rect.height}`)
      $("#gameContainer").width(rect.width).height(rect.height);
    }
  }
}
</script>
<style scoped>
.content{
  position: relative;
  overflow: hidden;
}
#gameContainer, .recognize-area {
  position: absolute;
  left: 0;
  width: 100%;
  height: 100%;
}

</style>