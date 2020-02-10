const state = {
  config: {
    googleMaps: {
      apiKey: 'AIzaSyBNAqPrTQoz9P4NBlDDyfxrnKiafkaL8iQ'
    },
    windowMatchSizeLg: '(min-width: 992px)',
  },
  isLoading: true,
  login: {
    name: '',
    email: '',
    token: '',
    claims: '',
    ID : ''
  }   
}

export default {
  state,
  mutations: {
    SETTOKEN(state, payload) {
      state.login.name = payload.Name;
      state.login.email = payload.Email;
      state.login.token = payload.Token;
      state.login.claims = payload.Claims;
      state.login.ID = payload.Id;
    }
  }
}
