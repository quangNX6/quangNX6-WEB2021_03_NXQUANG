import Vue from 'vue'
import App from './App.vue'
import VueRouter from 'vue-router'
import axios from 'axios'
import VueAxios from 'vue-axios'
import * as Tabs from 'vue-slim-tabs'

import CustomerList from './components/page/CustomerList.vue'
import ReportList from './components/page/ReportList.vue'
Vue.config.productionTip = false

// 1.Định nghĩa các Path
const routes = [
  { path: '/customer', component: CustomerList },
  { path: '/report', component: ReportList }
]

// 2.khởi tạo router
const router = new VueRouter({
  routes // short for `routes: routes`
})

// 3.khai báo s/d Vue-Router
Vue.use(VueRouter)
Vue.use(Tabs)
new Vue({
  router,
  render: h => h(App),
}).$mount('#app')



Vue.use(VueAxios, axios)



