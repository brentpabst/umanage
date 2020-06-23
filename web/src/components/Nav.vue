<template>
  <header class="uk-margin-medium-bottom">
    <nav class="uk-navbar-container uk-box-shadow-small">
      <div class="uk-container">
        <div class="uk-navbar">
          <div class="uk-navbar-left">
            <router-link
              to="/"
              class="uk-navbar-item"
            >
              <logo />
            </router-link>
          </div>
          <div class="uk-navbar-right">
            <div class="uk-navbar-item">
              <search />
            </div>
            <div
              class="uk-navbar-item"
              uk-toggle="target: #personal-menu"
            >
              <img
                class="uk-border-circle uk-margin-small-right"
                style="max-height: 30px;"
                src="https://via.placeholder.com/175/2196f3/ffffff.webp?text=JD"
                alt="user picture"
              >
              <span uk-icon="chevron-down" />
            </div>
            <div
              id="personal-menu"
              uk-offcanvas="flip: true; overlay: true"
            >
              <div class="uk-offcanvas-bar">
                <div class="user-profile-link">
                  <router-link to="/me">
                    <img
                      class="uk-border-circle uk-margin-small-right"
                      style="max-height: 30px;"
                      src="https://via.placeholder.com/175/2196f3/ffffff.webp?text=JD"
                      alt="user picture"
                    >
                    Go to Profile <span uk-icon="arrow-right" />
                  </router-link>
                </div>
                <button
                  class="uk-offcanvas-close uk-close-large"
                  type="button"
                  uk-close
                />
                <ul class="uk-nav uk-nav-default">
                  <li
                    v-for="item in menu"
                    :key="item.order"
                  >
                    <a :href="item.url">
                      <span
                        v-if="!!item.icon"
                        class="uk-margin-small-right"
                        :uk-icon="'icon: ' + item.icon"
                      />
                      {{ item.title }}
                    </a>
                  </li>
                </ul>
              </div>
            </div>
          </div>
        </div>
      </div>
    </nav>
  </header>
</template>

<style lang="scss" scoped>
.uk-offcanvas-bar {
  padding-top: 80px;
}

.user-profile-link {
  position: absolute;
  top: 20px;
  left: 20px;
}
</style>

<script>
import { mapState } from 'vuex'
import Logo from '@/components/Logo'
import Search from '@/components/Search'

export default {
  components: { Logo, Search },
  computed: mapState({
    menu: state =>
      state.config.menu.sort((a, b) => {
        return a.order - b.order
      })
  }),
  created() {
    this.$store.dispatch('config/getConfig')
  }
}
</script>