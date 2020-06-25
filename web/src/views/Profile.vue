<template>
  <div class="home">
    <div class="uk-card uk-card-default uk-box-shadow-medium uk-padding uk-margin-bottom">
      <div uk-grid>
        <div>
          <img
            class="uk-border-circle"
            style="max-height: 175px;"
            src="https://via.placeholder.com/175/2196f3/ffffff.webp?text=JD"
            alt="user picture"
          >
        </div>
        <div>
          <h1 class="uk-heading-medium uk-text-light">
            {{ user.name }}
          </h1>
          <p>{{ user.title }} | <a>Charlotte</a> (3:28 PM)</p>
          <p>VoIP: 1234-567890 | M: +1234567890 | O: +1234567890 | <a :href="'mailto:'+user.email">E-mail {{ user.given_name }}</a></p>
          <p>Assistant: <a>John Smith</a> | VoIP: 1234-567890 | O: +1234567890</p>
        </div>
      </div>
    </div>

    <div class="uk-card uk-card-default uk-box-shadow-medium uk-padding">
      <p class="uk-text-uppercase uk-text-bold">
        My position in the company
      </p>
      <span class="uk-text-light">Role:</span>
      <br>
      {{ user.title }}
      <hr>
      <p class="uk-text-uppercase uk-text-bold">
        Contact Information
      </p>
      <div uk-grid>
        <div class="uk-width-expand">
          <p class="uk-text-uppercase">
            Contact
          </p>
          <span class="uk-text-light">E-mail:</span>
          <br>
          <a :href="'mailto:'+user.email">{{ user.email }}</a>
          <br>
          <span class="uk-text-light">VoIP:</span>
          <br>
          1234-567890
          <br>
          <span class="uk-text-light">Office:</span>
          <br>
          +1234567890
          <br>
          <span class="uk-text-light">Mobile:</span>
          <br>
          +1234567890
          <br>
          <span class="uk-text-light">Fax:</span>
          <br>
          +1234567890
        </div>
        <div class="uk-width-expand">
          <p class="uk-text-uppercase">
            Assistant
          </p>
          <span class="uk-text-light">Assistant:</span>
          <br>
          John Smith
          <br>
          <span class="uk-text-light">VoIP:</span>
          <br>
          1234-567890
          <br>
          <span class="uk-text-light">E-mail:</span>
          <br>
          john@example.com
          <br>
          <span class="uk-text-light">Office:</span>
          <br>
          +1234567890
        </div>
        <div class="uk-width-expand">
          <p class="uk-text-uppercase">
            Location
          </p>
          <span class="uk-text-light">Room:</span>
          <br>
          Room
          <br>
          <span class="uk-text-light">Office:</span>
          <br>
          {{ user.office_address.address1 }}
          <br>
          {{ user.office_address.address2 }}
          <br>
          {{ user.office_address.city }}, {{ user.office_address.province }}, {{ user.office_address.post_code }}
          <br>
          {{ user.office_address.country }}
        </div>
      </div>
      <hr>
      <p class="uk-text-uppercase uk-text-bold">
        Personal Information
      </p>
      Possible things to add: Home Address, Home Phone, Personal Mobile, Birthday, Pronouns, About Me, Languages
    </div>
  </div>
</template>

<script>
import { mapState } from 'vuex'

export default {
  computed: mapState({
    user: state => state.users.currentUser
  }),
  created() {
    this.$store.dispatch('users/getCurrentUser')
  }
}
</script>