import Vue from "vue";
import Vuex from "vuex";
import config from "./modules/config";
import users from "./modules/users";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {},
  mutations: {},
  actions: {},
  modules: {
    config,
    users,
  },
});
