import { createStore, applyMiddleware, compose } from 'redux'
import authFrontEnd from './reducers'
import initialState from './initialState'
import sagaMiddleware, { runSagas } from './sagas'

const middlewares = [
    sagaMiddleware
]

let store = createStore(authFrontEnd,
    initialState,
    compose(
        applyMiddleware(...middlewares),
        process.env.NODE_ENV === "development" && window.devToolsExtension ? window.devToolsExtension() : f => f
    ))

runSagas()

export default store