/*
export const someMutation = (state) => {
}
*/
export const POST_FETCHING = state => {
  state.isFecthing = true;
};
export const POST_FETCHING_FAILED = (state, message) => {
  state.isFecthing = false;
  state.error = true;
  state.error_message = message;
};
export const POST_FETCHING_DONE = state => {
  state.isFecthing = false;
};
export const SET_POSTS = (state, posts) => {
  state.posts = posts;
};
export const SET_POST = (state, post) => {
  state.post = post;
};
export const UPDATE_PENDING = state => {
  state.updating = true;
};
export const UPDATE_DONE = (state, payload) => {
  state.updating = false;
  state.post = payload;
};
export const UPDATE_FAILED = state => {
  state.updating_failed = true;
};
