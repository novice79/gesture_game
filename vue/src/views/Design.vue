<template>
  <div>
    <header>
      <div class="left" @click="$router.go(-1)">&larr;</div>
      设置手势
    </header>
    <div class="content">
      <input type="text" v-model="strokeName" placeholder="名称" v-bind:readonly="!$isDev">
      <textarea  rows="2" v-model="comments" placeholder="功能说明文字" v-bind:readonly="!$isDev"></textarea>
      <div class="scratch">
        <canvas></canvas>
      </div>
      <button class="save" @click.stop="save_ges">保存</button>

    </div>
  </div>
</template>

<script>
import recognizer from "@/js/dollar";
import RegCanvas from "@/js/reg_canvas";

export default {
  name: 'Design',
  props: {
    name: {
      type: String,
      default: "新手势"
    }
  },
  watch: { 
    name: function(newVal, oldVal) { 
      // watch it
      this.get_ges_info();
    }
  },
  data () {
    return {
      strokeName: '',
      comments: '',
      dirty: false
    }
  },
  beforeRouteLeave (to, from, next) {
    do{
      if ( !this.dirty ) break;
      const ok = confirm("手势尚未保存，确认放弃修改吗？");
      if(ok) break;
      return next(false)
    }while(0);
    this.dirty = false
    // this.reg_canvas.clear()
    // this.comments = ''
    next()
  },
  mounted () {
    const canvas = document.querySelector('.scratch > canvas');  
    const rect = canvas.parentNode.getBoundingClientRect();
    canvas.width = rect.width;
    canvas.height = rect.height;
    let dealer = {
      touchstart: ch => {
        ch.clear()
        this.dirty = true
      }
    }
    this.reg_canvas = new RegCanvas(canvas, dealer)  
    this.get_ges_info();
  },

  methods: {
    get_ges_info() {
      this.strokeName = decodeURIComponent(this.name)
      this.stroke = recognizer.GetUnistroke(this.strokeName);
      this.comments = this.stroke.Comments;
      this.reg_canvas.draw_stroke(this.stroke.Name)
    },

    save_ges (event) {
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
.scratch {
  flex : 1 1 auto;
  border : 2px solid red;
}
input{
  text-align: center;
}
input, textarea, .save{
  font-size: 1.5rem;
}
textarea{
  min-height: 2em;
}
.save{
  background-color: rgb(222, 253, 110);
}
</style>