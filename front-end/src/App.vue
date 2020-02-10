<template>
  <div id="app">
    <div class="loading" v-if="this.$root.Loading.show">Loading&#8230;</div>
    <div id="main-wrapper" v-if="!isAuth">
      <vue-min-header></vue-min-header>
      <Sidebar :navItems="nav"/>
      <div class="page-wrapper">
        <vue-min-breadcrumb></vue-min-breadcrumb>
        <div class="container-fluid">
          <router-view></router-view>
        </div>
      </div>
      <vue-footer></vue-footer>
    </div>
    <router-view v-else></router-view>
  </div>
</template>

<script>
import nav from './nav'
import Header from './components/global/Header.vue';
import Breadcrumb from './components/global/Breadcrumb.vue';
import Sidebar from './components/global/Sidebar.vue';
import Footer from './components/global/Footer.vue';

export default {
    data (){
      return{
        nav: nav.items
      }
    },
    mounted(){
      if(this.$store.state.app.login.token != '')
        this.$router.push('dashboard');
    },
    components: {
      VueMinHeader: Header,
      VueMinBreadcrumb: Breadcrumb,
      Sidebar,
      VueFooter: Footer
    },
    computed: {
      name(){
        return this.$route.name
      },
      list() {
        return this.$route.matched
      },
      isAuth () {
        return this.$route.path === "/";
      }
    }
}
</script>

<style lang="scss">
[v-cloak] {
    display: none;
}

@import "./assets/css/lib/bootstrap/bootstrap.min.css";
@import "~pure-semantic-ui-css/semantic.css";
@import "./assets/css/lib/calendar2/pignose.calendar.min.css";
@import "~owl-carousel-2/assets/owl.carousel.min.css";
@import "~owl-carousel-2/assets/owl.theme.default.min.css";

@import "./assets/icons/font-awesome/css/font-awesome.min.css";
@import "./assets/icons/simple-line-icons/css/simple-line-icons.css";
@import "./assets/icons/weather-icons/css/weather-icons.min.css";
@import "./assets/icons/themify-icons/themify-icons.css";
@import "./assets/icons/material-design-iconic-font/css/materialdesignicons.min.css";

@import "./assets/css/helper.css";
@import "./assets/css/style.css";

  .card-header{
    margin: -20px -20px 20px -20px;
  }
  .card-footer{
    margin: 20px -20px -20px -20px;
  }
  .card-text{
    padding: 10px;
  }

  /* Absolute Center Spinner */
.loading {
  position: fixed;
  z-index: 999;
  height: 2em;
  width: 2em;
  overflow: visible;
  margin: auto;
  top: 0;
  left: 0;
  bottom: 0;
  right: 0;
}

/* Transparent Overlay */
.loading:before {
  content: '';
  display: block;
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(167, 193, 211, 0.493);
}

/* :not(:required) hides these rules from IE9 and below */
.loading:not(:required) {
  /* hide "loading..." text */
  font: 0/0 a;
  color: transparent;
  text-shadow: none;
  background-color: transparent;
  border: 0;
}

.loading:not(:required):after {
  content: '';
  display: block;
  font-size: 10px;
  width: 1em;
  height: 1em;
  margin-top: -0.5em;
  -webkit-animation: spinner 1500ms infinite linear;
  -moz-animation: spinner 1500ms infinite linear;
  -ms-animation: spinner 1500ms infinite linear;
  -o-animation: spinner 1500ms infinite linear;
  animation: spinner 1500ms infinite linear;
  border-radius: 0.5em;
  -webkit-box-shadow: rgba(0, 140, 255, 0.938) 1.5em 0 0 0, rgba(0, 140, 255, 0.938) 1.1em 1.1em 0 0, rgba(0, 140, 255, 0.938) 0 1.5em 0 0, rgba(0, 140, 255, 0.938) -1.1em 1.1em 0 0, rgba(0, 0, 0, 0.5) -1.5em 0 0 0, rgba(0, 0, 0, 0.5) -1.1em -1.1em 0 0, rgba(0, 140, 255, 0.938) 0 -1.5em 0 0, rgba(0, 140, 255, 0.938) 1.1em -1.1em 0 0;
  box-shadow: rgba(0, 140, 255, 0.938) 1.5em 0 0 0, rgba(0, 140, 255, 0.938) 1.1em 1.1em 0 0, rgba(0, 140, 255, 0.938) 0 1.5em 0 0, rgba(0, 140, 255, 0.938) -1.1em 1.1em 0 0, rgba(0, 140, 255, 0.938) -1.5em 0 0 0, rgba(0, 140, 255, 0.938) -1.1em -1.1em 0 0, rgba(0, 140, 255, 0.938) 0 -1.5em 0 0, rgba(0, 140, 255, 0.938) 1.1em -1.1em 0 0;
}

/* Animation */

@-webkit-keyframes spinner {
  0% {
    -webkit-transform: rotate(0deg);
    -moz-transform: rotate(0deg);
    -ms-transform: rotate(0deg);
    -o-transform: rotate(0deg);
    transform: rotate(0deg);
  }
  100% {
    -webkit-transform: rotate(360deg);
    -moz-transform: rotate(360deg);
    -ms-transform: rotate(360deg);
    -o-transform: rotate(360deg);
    transform: rotate(360deg);
  }
}
@-moz-keyframes spinner {
  0% {
    -webkit-transform: rotate(0deg);
    -moz-transform: rotate(0deg);
    -ms-transform: rotate(0deg);
    -o-transform: rotate(0deg);
    transform: rotate(0deg);
  }
  100% {
    -webkit-transform: rotate(360deg);
    -moz-transform: rotate(360deg);
    -ms-transform: rotate(360deg);
    -o-transform: rotate(360deg);
    transform: rotate(360deg);
  }
}
@-o-keyframes spinner {
  0% {
    -webkit-transform: rotate(0deg);
    -moz-transform: rotate(0deg);
    -ms-transform: rotate(0deg);
    -o-transform: rotate(0deg);
    transform: rotate(0deg);
  }
  100% {
    -webkit-transform: rotate(360deg);
    -moz-transform: rotate(360deg);
    -ms-transform: rotate(360deg);
    -o-transform: rotate(360deg);
    transform: rotate(360deg);
  }
}
@keyframes spinner {
  0% {
    -webkit-transform: rotate(0deg);
    -moz-transform: rotate(0deg);
    -ms-transform: rotate(0deg);
    -o-transform: rotate(0deg);
    transform: rotate(0deg);
  }
  100% {
    -webkit-transform: rotate(360deg);
    -moz-transform: rotate(360deg);
    -ms-transform: rotate(360deg);
    -o-transform: rotate(360deg);
    transform: rotate(360deg);
  }
}

</style>
