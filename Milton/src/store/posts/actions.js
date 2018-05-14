/*
export const someAction = (state) => {
}
*/

export function fetchNewestPost({ state, commit }) {
  const axios = this._vm.$axios;
  commit('POST_FETCHING');
  return axios.get('/posts').then(res => {
    commit('POST_FETCHING_DONE');
    commit('SET_POST', res.data.text);
    return res.data.text;
  });
}

export function update({ commit }, payload) {
  const axios = this._vm.$axios;
  commit('UPDATE_PENDING');
  return axios.post('/posts', payload).then(res => {
    const { data } = res;
    commit('UPDATE_DONE', payload.text);
    if (data.status !== 'success') {
      commit('UPDATE_FAILED');
      return false;
    }
    return true;
  });
}
