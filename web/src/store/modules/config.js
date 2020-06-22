import api from "../../services/api";
const state = () => ({
  menu: [],
});

const getters = {};

const actions = {
  getConfig({ commit }) {
    api.getConfig((conf) => {
      commit("setMenu", conf.menu);
    });
  },
};

const mutations = {
  setMenu(state, menu) {
    state.menu = menu;
  },
};

export default {
  namespaced: true,
  state,
  getters,
  actions,
  mutations,
};
