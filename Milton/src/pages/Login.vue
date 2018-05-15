<template>
  <q-page padding >
    <h3>Login to Milton</h3>
    <q-field icon="email">
      <q-input v-model="email" float-label="Email"/>
    </q-field>
    <q-field icon="lock">
      <q-input v-model="password" type="password" float-label="Password"/>
    </q-field>
    <q-btn color="primary" @click="loginHandler">Login</q-btn>
  </q-page>
</template>

<script>
import { mapActions } from 'vuex';
export default {
  data() {
    return {
      email: '',
      password: ''
    };
  },
  methods: {
    ...mapActions('auth', ['login']),
    loginHandler() {
      this.login({ email: this.email, password: this.password })
        .then(success => {
          if (!success) {
            return this.$q.notify({
              type: 'negative',
              message: 'Something is wrong'
            });
          }
          this.$router.push('/');
        })
        .catch(err => {
          console.log(err.message);
        });
    }
  }
};
</script>
