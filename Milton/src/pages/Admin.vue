<template>
  <q-page padding>
    <q-field
    orientation="vertical"
     icon="edit" label="Edit the about me page">
      <q-editor v-model="text" />
      <q-btn class="q-my-md" @click="updateHandler" :loading="updating" color="primary" >Update</q-btn>
    </q-field>
    <q-field
    class="q-my-md"
    orientation="vertical"
    icon="library_add"
    label="Add more pictures">
      <q-uploader :url="url" :headers="headers" />
    </q-field>

  </q-page>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';
export default {
  name: 'admin',
  created() {
    if (this.text === '') {
      this.fetchNewestPost().then(text => {
        this.text = text;
      });
    }
  },
  data() {
    return {
      text: '',
      url: 'http://localhost:5000/file/upload',
      updating: false
    };
  },
  computed: {
    // ...mapGetters('posts', ['post']),

    ...mapGetters('auth', ['token']),
    headers() {
      return { Authorization: this.token };
    }
  },
  methods: {
    ...mapActions('posts', ['fetchNewestPost', 'update']),
    updateHandler() {
      this.updating = true;
      this.update({ text: this.text }).then(success => {
        if (!success) {
          return this.$q.notify({
            type: 'negative',
            message: 'Something went wrong ¯_(ツ)_/¯'
          });
        }
        this.updating = false;
        this.$q.notify({
          type: 'positive',
          message: 'Successfully changed the About Me Page'
        });
      });
    }
  }
};
</script>
