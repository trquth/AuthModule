import React from 'react'
import "./../../../contents/css/style.css"

let Login = ({
    userName,
    password,
    onChangeUserName,
    onChangePassword,
    onSubmitForm
}) => {
    return <div className="login-form">
        <div className="head">
        </div>
        <div className="head-info">
            <h1>Sign up in seconds</h1>
        </div>
        <form onSubmit={(e) => onSubmitForm(e, userName, password)}>
            <li>
                <input type="text" onChange={(e) => onChangeUserName(e)} className="text"  value={userName} placeholder="User Name" /><a href="#" className=" icon user"></a>
            </li>
            <li>
                <input type="password" onChange={(e) => onChangePassword(e)}  value={password} placeholder="Password" /><a href="#" className=" icon lock"></a>
            </li>
            <div className="p-container">
                <input type="submit" defaultValue="Sign me up!" />
                <div className="clear"> </div>
            </div>
        </form>
        <div className="social-icons">
            <p>..or you can skip that and sign up via</p>
            <a href="#"><ul className="facebook">
                <li><img src={require('./../../../contents/images/fb.png')} /></li>
                <li>Connect</li>
            </ul></a>
            <a href="#"><ul className="twitter">
                <li><img src={require('./../../../contents/images/tw.png')} /></li>
                <li>Connect</li>
            </ul></a>
            <div className="clear"> </div>
        </div>
        <div className="copy-right">
            <p>Template by <a href="http://w3layouts.com">w3layouts</a></p>
        </div>
    </div>
}
export default Login