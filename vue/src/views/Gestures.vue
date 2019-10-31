<template>
  <div class="gestures">
    <header>
      <div class="left" @click="$router.go(-1)">&larr;</div>
        手势绑定
      <div class="right">
        <div v-if="$isDev" @click.stop="$router.push({name: 'design'})">+</div>
        <div  class="save" @click.stop="save_gestures()">&#128190;</div>
        <div class="restore-def" @click.stop="restore_default_gestures()">&#x21bb;</div>
      </div>      
    </header>
    
    <div class="content">
      <div class="list">
        <div v-for="s in strokes" class="stroke">
          <canvas :id="s.Name" width="250" height="250"></canvas>
          <div class="desc">
            <h3 >{{s.Name}}</h3>
            <h4 class="comments">{{s.Comments}}</h4>
            <button class="edit" @click.stop="goDesign(s.Name)" >编辑</button>
            <button v-if="$isDev" class="delete" @click.stop="delete_stroke(s.Name)" >删除</button>
          </div>
        </div>
      </div>

    </div>
  </div>
</template>

<script>
import recognizer from "@/js/dollar";
import util from "@/js/util";
import def_ges from "@/default_gestures";
export default {
  name: "Gestures",
  created: function() {
    // `this` points to the vm instance
    this.recognizer = recognizer;
    // console.log(`this.recognizer=`, this.recognizer);
    // console.log(this.myGlobalMethod(), this.$myMethod('ccc') );
  },
  data() {
    return {
      strokes: []
    };
  },
  computed: {
    libs() {
      return this.recognizer.StringifyGestures();
    }
    // strokes() {
    //   return this.recognizer.GetUnistrokes().slice(0);
    // }
  },
  mounted() {
    // first load
    this.loadStrokes();
  },
  activated() {
    // reenter
    this.loadStrokes();
  },
  methods: {
    restore_default_gestures() {
      const ok = confirm("确认恢复默认手势吗？");
      if(ok) {
        recognizer.Clear();
        recognizer.ParseInGestures(def_ges);
        localStorage.setItem('gestures', def_ges);
        this.loadStrokes();
        alert("恢复默认手持成功", "手势已重置");  
      }
      
    },
    async save_gestures() {
      let ges = this.recognizer.StringifyGestures();
      localStorage.setItem('gestures', ges);
      if(!window.cordova) {
        alert(`保存手势设置成功！`)
        return;
      }
      const dirEntry = await util.create_dir_recursive('mystore');
      const fn = 'gestures.js'; 
      dirEntry.getFile(
        fn,
        { create: true, exclusive: false },
        fileEntry => {
            fileEntry.createWriter(fileWriter => {
                fileWriter.onwriteend = () => {
                    console.log(`write ${fn} file successful...`);
                    alert(`保存手势设置成功！`)
                };
                fileWriter.onerror = (e) => {
                    console.log(`write ${fn} file failed: ` + JSON.stringify(e));
                    alert(`保存手势设置失败！`)
                };
                ges = `export default \`${ges}\`;`;
                const dataObj = new Blob([ges], { type: 'text/javascript' });
                fileWriter.write(dataObj);
            });
        },
        err => { }
      );
    },
    delete_stroke(name) {
      this.recognizer.DeleteByName(name);
      this.loadStrokes();
    },
    loadStrokes() {
      this.strokes = this.recognizer.GetUnistrokes().slice(0);
      this.$nextTick(() => {
        this.drawStrokes();
      });
    },
    goDesign(name) {
      this.$router.push({ name: 'design', params: { name } });
    },
    drawStrokes() {
      this.recognizer.GetUnistrokes().forEach(s => {
        // console.log(s.Name);
        var can_mini = document.getElementById(s.Name);
        var context_mini = can_mini.getContext("2d");
        context_mini.clearRect(0, 0, can_mini.width, can_mini.height);
        context_mini.beginPath();
        var Origin = {
          X: 250.0 / 2,
          Y: 250.0 / 2 + 5
        };
        var ps = this.recognizer.GetGesturePoints(s.Name, 200, Origin);
        // console.log(ps);
        context_mini.moveTo(ps[0].X, ps[0].Y);
        for (var i = 1; i < ps.length; ++i) {
          context_mini.lineTo(ps[i].X, ps[i].Y);
          context_mini.stroke();
        }
      });
    }
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.stroke {
  display: flex;
  flex-direction: row;
  border: 2px outset gray;
}
.desc{
  flex: 1;
  text-align: center;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
}
.comments {
  flex: 1;
}

h3 {
  color: purple;
}
.edit, .delete{
  width: 79%;
  margin: 0.2em;
  font-size: 1.2em;
  border-radius: 0.7em;
}
.edit{
  background-color: aquamarine;
}
.delete{
  background-color: rgb(243, 149, 8);
}
.right{
  top: 0;
  font-size: 1.7rem; 
  display: flex;
  justify-content: center;
}
.save{
  font-size: 1.2rem; 
}
.right > div{
  margin: 0 0.2em;
}
</style>
