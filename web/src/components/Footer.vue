<template>
  <footer class="uk-container uk-padding-small uk-text-meta">
    {{ $tc('footer.copyright') }} &copy; {{ new Date().getFullYear() }} <a href="https://www.brentpabst.com">Brenton Pabst</a> {{ $tc('footer.provided') }} <a href="https://github.com/brentpabst/umanage/blob/master/LICENSE">MIT License</a>
  </footer>
</template>

<script>
export default {
  name: 'Footer'
}
</script>