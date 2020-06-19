<template>
  <div id="app">
    <header>
      <nav class="uk-navbar-container">
        <div class="uk-container">
          <div class="uk-navbar">
            <div class="uk-navbar-left">
              <router-link
                to="/"
                class="uk-navbar-item uk-logo"
              >
                <img
                  src="@/assets/logo.png"
                  style="max-height: 50px;"
                  alt="umanage logo"
                  uk-img
                >
              </router-link>
            </div>
          </div>
        </div>
      </nav>
    </header>
    <router-view />
  </div>
</template>
