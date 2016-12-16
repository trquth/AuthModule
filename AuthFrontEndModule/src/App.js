import React, { Component } from 'react';
import { LoginContainer } from "./modules/auth"
import { ErrorPageContainer } from "./modules/common"

class App extends Component {
  render() {
    return (
      <ErrorPageContainer />
    )
  }
}

export default App;
