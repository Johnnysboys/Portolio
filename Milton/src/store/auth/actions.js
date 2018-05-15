/*
export const someAction = (state) => {
}
*/
import jwtDecode from 'jwt-decode';
import { LocalStorage } from 'quasar';

export function login({ commit }, payload) {
  const axios = this._vm.$axios;

  return axios.post('/token/auth', payload).then(res => {
    if (res.data.status === 'Error') return false;
    const token = res.data.token;
    LocalStorage.set('jwt', token);

    const decodedToken = jwtDecode(token);
    const user = decodedToken.user;
    commit('STORE_USER', user);
    commit('STORE_TOKEN', token);
    return true;
  });
}
export function setToken({ commit }, token) {}

export function logout({ commit }) {
  return new Promise((resolve, reject) => {
    LocalStorage.remove('jwt');
    commit('RESET_STATE');
    resolve(true);
  });
}

export function checkStorage({ commit }) {
  if (LocalStorage.has('jwt')) {
    const token = LocalStorage.get.item('jwt');
    const decodedToken = jwtDecode(token);
    const user = decodedToken.user;
    // Check if the token has expired
    // Date.now() is in ms, exp is in sec, / 1000 to get secs
    if (decodedToken.exp < Date.now() / 1000) return LocalStorage.remove('jwt');

    commit('STORE_USER', user);
    commit('STORE_TOKEN', token);
  }
}
