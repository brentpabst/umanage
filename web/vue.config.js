module.exports = {
  productionSourceMap: false,

  pwa: {
    name: 'umanage'
  },

  outputDir: '../bin/public',

  pluginOptions: {
    i18n: {
      locale: 'en',
      fallbackLocale: 'en',
      localeDir: 'locales',
      enableInSFC: false
    }
  }
}
