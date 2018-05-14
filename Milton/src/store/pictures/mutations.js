/*
export const someMutation = (state) => {
}
*/
export const FETCHING = state => {
  state.fetching = true;
};
export const FETCHING_DONE = state => {
  state.fetching = false;
};
export const SET_FILES = (state, files) => {
  state.files = files;
};
