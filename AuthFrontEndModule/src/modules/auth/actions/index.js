export const REQUEST_LOGIN = "REQUEST_LOGIN"
export function requestLogin(userName, password){
    return {
        type : REQUEST_LOGIN,
        userName, password
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