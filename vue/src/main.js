import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
window.$ = require('jquery')
Vue.config.productionTip = false
Vue.prototype.window = window;
const MyPlugin = {
  install (Vue, options) {
    // 1. add global method or property
    Vue.myGlobalMethod = function () {
      console.log(options)
      return 'aaaa';
    }
    Vue.prototype.$myMethod = function (methodOptions) {
      console.log(methodOptions, options)
      return 'bbbb';
    }
    Vue.prototype.$isDev = options.dev;
  }
}
Vue.use(MyPlugin, { dev: false })
const startApp = ()=>{
  window.vm = new Vue({
    router,
    store,
    render: h => h(App)
  }).$mount('#app')
}
if(!!window.cordova){
  document.addEventListener("deviceready", ()=>{
    startApp()
  }, false); 
} else {
  startApp()
}


