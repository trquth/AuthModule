import React, { Component } from "react"
import { withRouter } from 'react-router'
import Login from "./../presenters/Login"

class LoginContainer extends Component {
    render() {
        return <Login />
    }
}
export default withRouter(LoginContainer)
