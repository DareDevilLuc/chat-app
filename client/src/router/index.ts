import { createRouter, createWebHistory } from 'vue-router'
import SignUpView from '@/views/SignUpView.vue'
import ChatView from '@/views/ChatView.vue'
import LoginView from '@/views/LoginView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/main',
      component: ChatView
    },
    {
      path: '/signup',
      component: SignUpView
    },
    {
      path: '/login',
      component: LoginView
    }
  ],
})

router.beforeEach((to, from) => {
  const token = localStorage.getItem('token')

  if(!token  && to.path != '/login'){
    return '/login'
  }
})

export default router
