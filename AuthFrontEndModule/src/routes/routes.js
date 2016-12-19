import React from 'react'
import { Router, Route, IndexRoute, browserHistory } from 'react-router'
import App from './../App'
import { LoginContainer } from './../modules/auth'

export default (
    <Router history={browserHistory}>
        <Route path="/" component={App}>
            <Route path="login" component={LoginContainer} />
        </Route>
    </Router>
)