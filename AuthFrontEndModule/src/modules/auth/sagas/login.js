import {call, put} from 'redux-saga/effects'
import {takeLatest} from 'redux-saga'
import constants from './../../../constants'
import FetchHelper from './../../../helpers/FetchHelper'
import {
	REQUEST_LOGIN,
	requestLoginFail, 
	requestLoginSuccess,
	requestRefreshTokenRepeatedly
} from './../actions'
import Logger from './../../../helpers/Logger'
import { browserHistory } from 'react-router'

////
function requestLogin(userName, password, rememberMe){
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

function requestPermissions(){
	return FetchHelper.fetch(`${constants.api_root}api/User/GetPermissions`)
}

export default function* watchLogin(){
	yield takeLatest(REQUEST_LOGIN, login)
}

function* login({userName, password, rememberMe}){
	try{
		const [data] = yield call(requestLogin, userName, password, rememberMe)
		if (data && data.access_token){
			//login success
			FetchHelper.addDefaultHeader('Authorization', `Bearer ${data.access_token}`)

			//request permissions
			try{
				const permissionResponse = yield call(requestPermissions)
				const permissionData = permissionResponse[0]
				if (permissionData){
					yield put(requestLoginSuccess(permissionData))
					yield put(requestRefreshTokenRepeatedly({
						expiresIn: data.expires_in,
						refreshToken: data.refresh_token
					}))

					saveUserSession({
						status: 'success', //'init'/'fetching'/'success'/'fail'
				        userName: userName,
				        rememberMe: rememberMe,
				        expiresIn: parseFloat(data.expires_in)*60*1000,//millisecond
				        accessToken: data.access_token,
				        refreshToken: data.refresh_token,
				        updatedAt: Date.now(),
				        permissions: permissionData//TODO - handle permission
					})
					//go to payroll-configuration page
					browserHistory.push('/payroll-configuration')
				}else{
					throw new Error('Request permissions receive empty response')
				}
			}catch(e){
				Logger.error(e)
				throw e
			}
		}else{
			throw new Error('Empty response on request login')
		}
	}catch(err){
		//login fail
		Logger.error(err)
		yield put(requestLoginFail())
	}
}

export function saveUserSession(account){
	const accountStr = JSON.stringify(account)
    if (account.rememberMe){
        localStorage['store.account'] = accountStr
    }else{
        sessionStorage['store.account'] = accountStr
        localStorage.removeItem('store.account')
    }
}


