/*
export const someMutation = (state) => {
}
*/
export function STORE_TOKEN(state, token) {
  this._vm.$axios.defaults.headers.common['Authorization'] = token;
  state.token = token;
}
export function STORE_USER(state, user) {
  state.user = user;
}
export function RESET_STATE(state) {
  state.user = null;
  state.token = null;
}
