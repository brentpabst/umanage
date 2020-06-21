<template>
  <div id="app">
    <header class="uk-margin-medium-bottom">
      <nav class="uk-navbar-container uk-box-shadow-small">
        <div class="uk-container">
          <div class="uk-navbar">
            <div class="uk-navbar-left">
              <router-link
                to="/"
                class="uk-navbar-item uk-logo"
              >
                <img
                  src="@/assets/logo.svg"
                  alt="umanage logo"
                  uk-svg
                >
              </router-link>
            </div>
            <div class="uk-navbar-right">
              <div class="uk-navbar-item">
                <div>
                  <a class="uk-navbar-toggle">
                    <span uk-search-icon />
                  </a>
                  <div
                    class="uk-drop"
                    uk-drop="mode: click; pos: left-center; offset: 0"
                  >
                    <form class="uk-search uk-search-navbar uk-width-1-1">
                      <label for="search">
                        <!-- eslint-disable vue-a11y/no-autofocus -->
                        <input
                          ref="search"
                          class="uk-search-input"
                          type="search"
                          placeholder="Search for colleagues"
                          autofocus="autofocus"
                        >
                        <!-- eslint-enable vue-a11y/no-autofocus -->
                      </label>
                    </form>
                  </div>
                </div>
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
                    <li>
                      <a href="#">Menu Item 1</a>
                    </li>
                  </ul>
                </div>
              </div>
            </div>
          </div>
        </div>
      </nav>
    </header>
    <div class="uk-container">
      <router-view />
    </div>
    <footer class="uk-container uk-padding-small uk-text-meta">
      Copyright &copy; {{ new Date().getFullYear() }} <a href="https://www.brentpabst.com">Brenton Pabst</a> provided under the <a href="https://github.com/brentpabst/umanage/blob/master/LICENSE">MIT License</a>
    </footer>
  </div>
</template>

<style lang="scss" scoped>
.uk-logo {
  max-width: 170px;
  color: #2196f3;
}

.uk-offcanvas-bar {
  padding-top: 80px;
}

.user-profile-link {
  position: absolute;
  top: 20px;
  left: 20px;
}
</style>