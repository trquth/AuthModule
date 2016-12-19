import { combineReducers } from 'redux'
import { accounts } from './../modules/auth'

export default combineReducers({
    accounts: accounts
})