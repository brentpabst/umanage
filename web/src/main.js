import Vue from "vue";
import App from "./App.vue";
import "./registerServiceWorker";
import router from "./router";
import UIkit from "uikit";
import Icons from "uikit/dist/js/uikit-icons";
import "@/assets/styles/main.scss";
import i18n from './i18n'
import store from './store'

UIkit.use(Icons);
window.UIkit = UIkit;

Vue.config.productionTip = false;

new Vue({
  router,
  i18n,
  store,
  render: h => h(App)
}).$mount("#app");
