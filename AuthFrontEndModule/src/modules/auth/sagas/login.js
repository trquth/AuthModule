import { call, put } from 'redux-saga/effects'
import { takeLatest } from 'redux-saga'
import { browserHistory } from 'react-router'
import constants from './../../../constants'
import FetchHelper from './../../../helpers/FetchHelper'
import {
    REQUEST_LOGIN,
} from './../actions'


function requestLogin(userName, password) {
    return FetchHelper.fetch(`${constants.api_root}api/Account/Login`, {
        method: 'POST',
        body: JSON.stringify({
            "userName": userName,
            "password": password,
            "grant_type": "password",
            "client_id": constants.clientId,
            "useRefreshToken": true,
            "client_secret": constants.clientSecret
        })
    })
}

export default function* watchLogin() {
    yield takeLatest(REQUEST_LOGIN, login)
}

function* login({userName, password}) {
    debugger
    let [data] = yield call(requestLogin, userName, password)
    debugger
    if (data && data.access_token) {
        browserHistory.push('*')
    }
}