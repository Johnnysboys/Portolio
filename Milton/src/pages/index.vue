<template>
  <q-page class="" padding>
    <h3 class="text-center">My Portfolio</h3>
    <q-carousel
      color="white"
      arrows
      height="400px"
    >
      <q-carousel-slide v-for="image in files" :key="image" :img-src="`http://localhost:5000/Content/Images/${image}`" />
    </q-carousel>
  </q-page>
</template>

<style>

</style>

<script>
import { mapGetters, mapActions } from 'vuex';
export default {
  name: 'PageIndex',
  created() {
    this.fetch();
  },
  data() {
    return {};
  },
  computed: {
    ...mapGetters('pictures', ['files'])
  },
  methods: {
    ...mapActions('pictures', ['fetch'])
  }
};
</script>
