import createSagaMiddleware from 'redux-saga'
import { loginSaga } from './../modules/auth'

const sagas = [loginSaga]

const sagaMiddleware = createSagaMiddleware()

export default sagaMiddleware

export function runSagas() {
    sagas.forEach(saga => {
        sagaMiddleware.run(saga)
    })
}