import React from "react"
import "./../../../contents/css/errorPageStyle.css"

let ErrorPage = ({}) => {
    return <div>
        <div className="wrap" >
            <div className="logo">
                <img src={require('./../../../contents/images/404.png')} alt="" />
                <p><a href="#">Go back to Home</a></p>
            </div>
        </div>
        <div className="footer">
            Design by - <a href="http://w3layouts.com">W3Layouts</a>
        </div>
    </div>

}
export default ErrorPage