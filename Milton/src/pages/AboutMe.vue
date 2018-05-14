<template>
  <q-page padding>
    <h5>About me</h5>
    <div class="row justify-center">
      <span v-html="post" />
    </div>
  </q-page>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';
export default {
  name: 'aboutme',
  created() {
    if (this.post === '') {
      this.fetchNewestPost();
    }
  },
  data() {
    return {
      text: 'Fucker'
    };
  },
  computed: {
    ...mapGetters('posts', ['post'])
  },
  methods: {
    ...mapActions('posts', ['fetchNewestPost'])
  }
};
</script>
