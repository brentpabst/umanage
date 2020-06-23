<template>
  <div
    class="uk-logo"
    :style="{'max-width': width}"
  >
    <img
      src="@/assets/logo.svg"
      alt="umanage"
      uk-svg
    >
  </div>
</template>

<style lang="scss" scoped>
@import '../assets/styles/theme/import';
.uk-logo {
  color: $global-link-color;
}
</style>

<script>
export default {
  props: {
    width: {
      type: String,
      default: '170px'
    }
  }
}
</script>