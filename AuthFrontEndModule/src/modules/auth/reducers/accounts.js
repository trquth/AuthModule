import {
	REQUEST_LOGIN,	
	REQUEST_LOGIN_SUCCESS,
	REQUEST_LOGIN_FAIL,
	REQEUST_LOGOUT,
} from './../actions'

export default function account(state = {}, action) {
	switch (action.type) {
		case REQUEST_LOGIN:
			return Object.assign({}, state, {
				status: 'fetching',
				userName: action.userName,
				expiresIn: 0,
				accessToken: null,
				refreshToken: null
			})
		case REQUEST_LOGIN_SUCCESS:
			return Object.assign({}, state, {
				status: 'success',
				permissions: action.permissions
			})
		case REQUEST_LOGIN_FAIL:
			return Object.assign({}, state, {
				status: 'fail'
			})
		case REQEUST_LOGOUT:
			return {
				status: 'init'
			}
		default:
			return state
	}
}