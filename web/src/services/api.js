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

const _currentUser = {
  id: "9160f804-7b39-4cf1-974a-1ab0293a9087",
  user_name: "ironman",
  distinguished_name: "CN=Tony Stark,DC=StarkIndustries,DC=COM",
  locked: false,
  disabled: false,
  expired: false,
  expires: null,
  password_expires: null,
  name: "Tony Stark",
  display_name: "Anthony E. Stark",
  sort_name: "Stark, Anthony E.",
  given_name: "Anthony",
  middle_name: "Edward",
  family_name: "Stark",
  email: "tony@starkindustries.com",
  website: "warmachinesux.io",
  organization: "Stark Industries",
  department: "Management",
  title: "Chairman",
  office: "HQ",
  employee_id: "000002",
  badge_id: "1902jciohjec3",
  office_address: {
    address1: "1 Stark Way",
    address2: "",
    city: "Los Angeles",
    province: "CA",
    post_code: "90001",
    country: "United States",
  },
  phone_numbers: [
    {
      type: "office",
      number: 1,
      display: "+1",
      preferred: true,
    },
    {
      type: "home",
      number: 1,
      display: "+1",
      preferred: true,
    },
    {
      type: "mobile",
      number: 1,
      display: "+1",
      preferred: true,
    },
    {
      type: "sip",
      number: 1,
      display: "+1",
      preferred: true,
    },
    {
      type: "pager",
      number: 1,
      display: "+1",
      preferred: true,
    },
    {
      type: "fax",
      number: 1,
      display: "+1",
      preferred: true,
    },
  ],
};

export default {
  getConfig(cb) {
    setTimeout(() => cb(_config), 300);
  },

  getCurrentUser(cb) {
    setTimeout(() => cb(_currentUser), 300);
  },
};
