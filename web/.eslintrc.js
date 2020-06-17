module.exports = {
  root: true,
  env: {
    node: true
  },
  extends: [
    "plugin:vue/strongly-recommended",
    "eslint:recommended",
    "plugin:vue-a11y/base",
    "plugin:vue-a11y/recommended"
  ],
  parserOptions: {
    parser: "babel-eslint"
  },
  plugins: [
    "vue-a11y"
  ],
  rules: {
    "no-console": process.env.NODE_ENV === "production" ? "warn" : "off",
    "no-debugger": process.env.NODE_ENV === "production" ? "warn" : "off"
  },
  globals: {
    "UIkit": true
  }
};
