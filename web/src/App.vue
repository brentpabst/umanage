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
                Logo
              </router-link>
            </div>
          </div>
        </div>
      </nav>
    </header>
    <router-view />
  </div>
</template>
