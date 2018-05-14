import Vue from 'vue';
import Vuex from 'vuex';

import example from './module-example';
import auth from './auth';
import posts from './posts';
import pictures from './pictures';

Vue.use(Vuex);

const store = new Vuex.Store({
  modules: {
    example,
    auth,
    posts,
    pictures
  }
});

export default store;
