import Vue from "vue";
import VueRouter from "vue-router";
import Profile from "../views/Profile.vue";

Vue.use(VueRouter);

const routes = [
  {
    path: "/",
    name: "Root",
    redirect: "/me"
  },
  {
    path: "/me",
    name: "Profile",
    component: Profile
  }
];

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
});

export default router;
