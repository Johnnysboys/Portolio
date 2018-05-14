<template>
  <q-layout view="lHh Lpr lFf">
    <q-layout-header>
      <q-toolbar color="primary">
        <q-toolbar-title>
          Quasar App
          <div v-if="user != null" slot="subtitle">Hello {{ user.Email }}  {{ user.Admin ? 'You are admin' : ''}}</div>
        </q-toolbar-title>
        <q-tabs>
          <q-route-tab
            v-for="tab in tabs" :key="tabs[tab]"
            v-if="tab.admin ? (user ? (user.Admin ? true : false) : false) : true"
            :icon="tab.icon"
            :to="tab.to"
            exact
            slot="title"
          />
          </q-tabs>
        <q-btn v-if="user" @click="logout" label="Signout"/>
        <q-btn v-if="!user" @click="$router.push('/login')" label="Login"/>
      </q-toolbar>
    </q-layout-header>
    <q-page-container>
      <router-view />
    </q-page-container>
  </q-layout>
</template>

<script>
import { mapState, mapActions } from 'vuex';
export default {
  name: 'LayoutDefault',
  mounted() {},
  data() {
    return {
      tabs: [
        {
          name: 'home',
          icon: 'home',
          to: '/'
        },
        {
          name: 'newsletter',
          icon: 'email',
          to: '/newsletter'
        },
        {
          name: 'aboutme',
          icon: 'help',
          to: '/aboutme'
        },
        {
          name: 'admin',
          icon: 'person',
          to: '/admin',
          admin: true
        }
      ]
    };
  },
  computed: {
    ...mapState('auth', ['user'])
  },
  methods: {
    ...mapActions('auth', ['logout'])
  }
};
</script>

<style>

</style>
