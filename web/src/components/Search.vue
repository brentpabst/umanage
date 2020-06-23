<template>
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
            :placeholder="$tc('search.phrase')"
            autofocus="autofocus"
          >
          <!-- eslint-enable vue-a11y/no-autofocus -->
        </label>
      </form>
    </div>
  </div>
</template>