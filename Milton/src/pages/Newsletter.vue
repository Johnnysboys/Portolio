<template>
  <q-page padding>
    <div class="gutter-md justify-center">
      <div class="row justify-center">
        <h3>Sign up to my awesome newsletter</h3>
      </div>
      <div class="row justify-center">
        <q-field v-if="!icon" class="col-6" icon="email">
          <q-input v-model="email" float-label="Email"/>
        </q-field>
        <h4 v-if="icon">THANKS, I WILL SPAM YOU NOW</h4>
      </div>
      <div class="justify-center row">
        <q-btn
        :color="icon ? 'green' : 'primary'"
        :disabled="icon"
        :icon="icon ? 'done' : ''"
        :loading="subscribing" @click="signup"
        :label="icon ? '' : label" />
      </div>
    </div>
  </q-page>
</template>

<script>
export default {
  name: 'newletter',
  data() {
    return {
      email: '',
      subscribing: false,
      label: 'subscribe to my awesome newsletter',
      icon: false
    };
  },
  methods: {
    signup() {
      if (this.email === '') {
        return this.$q.notify({
          type: 'negative',
          message: 'there is no email!'
        });
      }
      if (!this.email.includes('@')) {
        return this.$q.notify({
          type: 'negative',
          message: 'That is not a vaildish email!'
        });
      }
      this.subscribing = true;

      this.$axios
        .post('/subscribers', { email: this.email })
        .then(response => {
          this.subscribing = false;
          this.icon = true;

          console.log(response.data);
        })
        .catch(err => {
          this.subscribing = false;

          this.$q.notify({
            type: 'negative',
            message: 'Error! : ' + err.message
          });
        });
    }
  }
};
</script>
