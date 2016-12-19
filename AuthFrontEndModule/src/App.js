import React, { Component } from 'react'
import { connect } from 'react-redux'
import { withRouter } from 'react-router'
import { LoginContainer } from "./modules/auth"
import { ErrorPageContainer } from "./modules/common"

class App extends Component {
  render() {
    return <div>
      {this.props.children}
    </div>
  }
}

export default withRouter(App)

// export default connect(state => {

// }, dispatch => {

// })(withRouter(App));
