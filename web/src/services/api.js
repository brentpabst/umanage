const _config = {
  menu: [
    {
      order: 1,
      title: "GitHub",
      url: "https://github.com/brentpabst/umanage",
      icon: "github",
    },
    {
      order: 0,
      title: "Brent Pabst",
      url: "https://brentpabst.com",
    },
  ],
};

export default {
  getConfig(cb) {
    setTimeout(() => cb(_config), 100);
  },
};
