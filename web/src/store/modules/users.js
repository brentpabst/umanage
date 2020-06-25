import api from "../../services/api";

const state = () => ({
  currentUser: {},
});

const getters = {};

const actions = {
  getCurrentUser({ commit }) {
    api.getCurrentUser((user) => {
      commit("setCurrentUser", user);
    });
  },
};

const mutations = {
  setCurrentUser(state, user) {
    state.currentUser = user;
  },
};

export default {
  namespaced: true,
  state,
  getters,
  actions,
  mutations,
};
