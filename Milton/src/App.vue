<template>
  <div id="q-app">
    <router-view />
  </div>
</template>

<script>
export default {
  name: 'App',
  beforeCreate() {
    // Check if the jwt key is stored
    this.$store.dispatch('auth/checkStorage');
  }
};
</script>

<style>

</style>
