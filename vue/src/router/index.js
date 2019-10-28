import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '@/views/Home.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'home',
    component: Home
  },
  {
    path: '/gestures',
    name: 'gestures',
    component: () => import('@/views/Gestures.vue')
  },
  {
    path: '/design',
    name: 'design',
    component: () => import('@/views/Design.vue')
  },
  {
    path: '/help',
    name: 'help',
    component: () => import(/* webpackChunkName: "help" */ '../views/Help.vue')
  }
]

const router = new VueRouter({
  routes
})

export default router
