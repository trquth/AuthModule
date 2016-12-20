
//LOGIN
export const REQUEST_LOGIN = "REQUEST_LOGIN"
export function requestLogin(userName, password, rememberMe){
	return {
		type: REQUEST_LOGIN,
		userName, password, rememberMe
	}
}

export const REQUEST_LOGIN_SUCCESS = "REQUEST_LOGIN_SUCCESS"
export function requestLoginSuccess(permissions){
	return {
		type: REQUEST_LOGIN_SUCCESS,
		permissions
	}
}

export const REQUEST_LOGIN_FAIL = "REQUEST_LOGIN_FAIL"
export function requestLoginFail(){
	return {
		type: REQUEST_LOGIN_FAIL
	}
}
//LOGOUT
export const REQUEST_LOGOUT = "REQUEST_LOGOUT"
export function requestLogout(){
	return {
		type: REQUEST_LOGOUT
	}
}

export const REQUEST_REFRESH_TOKEN_REPEATEDLY = 'REQUEST_REFRESH_TOKEN_REPEATEDLY'
/**
 *	Params:
 *		{
 *			refreshToken: refreshToken from got from server
 *			expiresIn: millisecond	
 *		}
 */
export function requestRefreshTokenRepeatedly({refreshToken, expiresIn, immediately}){
	return{
		type: REQUEST_REFRESH_TOKEN_REPEATEDLY,
		refreshToken, 
		expiresIn,
		immediately
	}
}

export const VALIDATE_ACCOUNT_STATE = "VALIDATE_ACCOUNT_STATE"
export function validateAccountState(){
	return {
		type: VALIDATE_ACCOUNT_STATE
	}
}
