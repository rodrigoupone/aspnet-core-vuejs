import Vue from 'vue'
import App from './App.vue'
import store from './store'
import VueRouter from 'vue-router';
import { routes } from './router/routes';
import axios from 'axios';


import BootstrapVue from 'bootstrap-vue'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'

import VueToast from 'vue-toast-notification';
import 'vue-toast-notification/dist/index.css';
Vue.use(VueToast, {
  position: 'bottom-left'
})

import moment from 'moment';

import vSelect from 'vue-select'
Vue.component('v-select', vSelect)

import 'sweetalert2/dist/sweetalert2.min.css';
import VueSweetalert2 from 'vue-sweetalert2';
Vue.use(VueSweetalert2);

Vue.filter('currency', function(value) {
  if (value) {
    return  value.toLocaleString('pt-BR', {
      minimumFractionDigits: 2,
      maximumFractionDigits: 2
    });
  }
})

Vue.filter('formatDate', function(value) {
  if (value) {
    return moment(String(value)).format('MM/DD/YYYY hh:mm')
  }
})

Vue.filter('shortDateTime', function(value) {
  if (value) {
    return moment(String(value)).format('MM/DD/YY hh:mm')
  }
})

Vue.prototype.$InputUP = function (requiredParam, value) {
  this.status = null;
  if (requiredParam == undefined) {
    this.required = true;
  } else {
    this.required = requiredParam;
  }
  this.value = value;
  this.ChangeStatus = function (statusParam) {
    this.status = statusParam;
  }
};

Vue.prototype.$globalClaims = "";
Vue.prototype.$http = axios;

Vue.prototype.$Loader = function () {
  this.show = false;
  this.Start = function () {
    this.show = true;
  }
  this.Stop = function () {
    this.show = false;
  }
};

Vue.use(BootstrapVue)
Vue.config.productionTip = false

// Router
Vue.use(VueRouter);
const router = new VueRouter({
  routes,
  linkActiveClass: 'open active',
  scrollBehavior: () => ({ y: 0 }),
  mode: 'hash',
});


new Vue({
  el: '#app',
  router,
  store,
  render: h => h(App),
  data() {
    return {
      Loading: new this.$Loader(false)
    }
  }, 
  mounted() {

    let _self = this;
    axios.interceptors.request.use(function (config) {
      _self.Loading.Start();
      return config;
    }, function (error) {
      _self.Loading.Stop();
      return Promise.reject(error);
    });

    axios.interceptors.response.use(function (response) {
      _self.Loading.Stop();
      return response;
    }, function (error) {
      _self.Loading.Stop();
      return Promise.reject(error);
    });


  },
})
