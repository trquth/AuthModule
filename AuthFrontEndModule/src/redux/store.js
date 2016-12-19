import { createStore, applyMiddleware, compose } from 'redux'
import authFrontEnd from './reducers'
import initialState from './initialState'

let store = createStore(authFrontEnd,
    initialState,
    compose(
        process.env.NODE_ENV === "development" && window.devToolsExtension ? window.devToolsExtension() : f => f
    ))


export default store