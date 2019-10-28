<template>
  <design id="design" data-page="true">
    <header class="header-bar">
      <div class="left">
        <button class="btn pull-left icon icon-arrow-back" data-navigation="$previous-page"></button>
        <h1 class="title">设置手势</h1>
      </div>
    </header>

    <div class="content">
      <input type="text" v-model="strokeName" placeholder="名称" v-bind:readonly="!$isDev">
      <textarea v-model="comments" placeholder="功能说明文字" v-bind:readonly="!$isDev"></textarea>
      <div class="recognize-area">
        <canvas></canvas>
      </div>
      <button class="btn primary" v-on:touchend="onSave">保存</button>

    </div>
  </design>
</template>

<script>
import Vue from 'vue'
import recognizer from "@/js/dollar";
import RegCanvas from "@/js/reg_canvas";

export default {
  name: 'DesignPage',
  data () {
    return {
      strokeName: '',
      comments: '',
      dirty: false
    }
  },

  mounted () {
    var canvas = document.querySelector('#design .content canvas');  
    var rect = canvas.parentNode.getBoundingClientRect();
    canvas.width = rect.width;
    canvas.height = rect.height;
    let dealer = {
      touchstart: ch => {
        ch.clear()
        this.dirty = true
      }
    }
    this.reg_canvas = new RegCanvas(canvas, dealer)  
  },

  methods: {
    onReady () {        
      $('body').on('touchmove', function (event) {
          event.preventDefault();
      }); // end body.onTouchMove
    },
    onClose (self) {
      if ( !this.dirty ) {
        self.close()
      } else {
        const ok = confirm("手势尚未保存，确认放弃修改吗？");
        if(ok) {
          self.close()
        }
      }
    },

    onHidden () {
      $('body').off('touchmove');
      this.dirty = false
      this.reg_canvas.clear()
      this.comments = ''
    },

    onHashChanged (sn) {
      this.strokeName = decodeURIComponent(sn)
      this.stroke = recognizer.GetUnistroke(this.strokeName);
      this.comments = this.stroke.Comments;
      this.reg_canvas.draw_stroke(this.stroke.Name)
    },

    onSave (event) {
      if(!this.dirty) return;
      if(this.strokeName && this.comments) {
        this.dirty = false
        this.reg_canvas.save(this.strokeName, this.comments)
        alert(`${this.strokeName} 手势已保存`);
      } else {
        alert(`名称或备注不能为空`);
      }
      
    }
  }
}
</script>
<style scoped>
.content {
  display: flex;
  flex-flow: column;
}
.recognize-area {
  flex : 1 1 auto;
  border : 2px solid red;
}


</style>