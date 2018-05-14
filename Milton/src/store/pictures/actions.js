/*
export const someAction = (state) => {
}
*/
export function fetch({ commit }) {
  commit('FETCHING');
  const axios = this._vm.$axios;

  axios
    .get('/file')
    .then(res => {
      const files = res.data.data;
      commit('FETCHING_DONE');
      commit('SET_FILES', files);
    })
    .catch(err => {
      commit('FETCHING_FAILURE');
      console.log(err.message);
    });
}
