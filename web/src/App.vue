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
              <ul class="uk-navbar-nav">
                <li class="uk-active">
                  <a href="#">My Profile</a>
                </li>
                <li><a href="#">Directory</a></li>
              </ul>
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
</style>