import React from 'react'
import "./../../../contents/css/style.css"

let Login = ({
    userName,
    password,
    onChangeUserName,
    onChangePassword,
    onSubmitForm
}) => {
    return <div>
        <div className="main">
            <h1>Rounded Flat User Login Form</h1>
            <form onSubmit={(e) => onSubmitForm(e, userName, password)}>
                <div className="input_form">
                    <input type="text" value={userName} onChange={(e) => onChangeUserName(e)} />
                    <input type="password" value={password} onChange={(e) => onChangePassword(e)} />
                </div>
                <div className="ckeck-bg">
                    <div className="checkbox-form">
                        <div className="check-left">
                            <div className="check">
                                <label className="checkbox"><input type="checkbox" name="checkbox" checked="" /><i> </i>Remember my Password</label>
                            </div>
                        </div>
                        <div className="check-right">
                            <input type="submit" value="Login" />
                        </div>
                        <div className="clearfix"></div>
                    </div>
                </div>
            </form>
        </div>
        <div className="footer">
            <p>&copy 2016 Rounded Flat User Login Form. All rights reserved | Design by <a href="http://w3layouts.com">W3layouts.</a></p>
        </div>
    </div>
}
export default Login