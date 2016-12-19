import React, { Component } from "react"
import { withRouter } from 'react-router'
import { connect } from 'react-redux'
import Login from "./../presenters/Login"
import { requestLogin } from './../actions'

class LoginContainer extends Component {
    constructor(props) {
        super(props)
        this.state = {
            userName: "",
            password: ""
        }
    }
    handleChangeUserName(e) {
        this.setState({
            userName: e.target.value
        })
    }
    handleChangePassword(e) {
        this.setState({
            password: e.target.value
        })
    }
    handlesubmitForm(e, userName, password) {
        e.preventDefault();
        this.props.onRequestLogin(userName, password)
    }
    render() {
        const {userName, password} = this.state
        return <Login
            userName={userName}
            password={password}
            onChangeUserName={this.handleChangeUserName.bind(this)}
            onChangePassword={this.handleChangePassword.bind(this)}
            onSubmitForm={this.handlesubmitForm.bind(this)} />
    }
}
export default connect(state => ({
}), dispatch => ({
    onRequestLogin: (userName, password) => dispatch(requestLogin(userName, password))
}))(withRouter(LoginContainer))
