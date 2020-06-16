import Vue from "vue";
import App from "./App.vue";
import "./registerServiceWorker";
import router from "./router";
import UIkit from "uikit";
import Icons from "uikit/dist/js/uikit-icons";
import "@/assets/styles/main.scss";

UIkit.use(Icons);
window.UIkit = UIkit;

Vue.config.productionTip = false;

new Vue({
  router,
  render: h => h(App)
}).$mount("#app");
