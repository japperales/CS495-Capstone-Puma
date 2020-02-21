﻿import React from 'react';
import M from 'materialize-css'
import './css/Login.css'

let state = {
    inputUserName: null,
    inputPassword: null,
    loginStatus: null,
    resp: ""
};

export class Login extends React.Component {
    onClickWrapperMethod(event){
        event.preventDefault();
        this.props.sendLogin(event);
    };

    componentDidMount(){
        console.log("component did mount");
        M.AutoInit();
    }

    componentWillUnmount(){
        state = this.state;
    }
    
    constructor(props){
        super(props);
        this.state = state;
        this.handleInputChange = this.handleInputChange.bind(this);
        this.onClickWrapperMethod = this.onClickWrapperMethod.bind(this);
    }

    async handleInputChange(event){

        const target = event.target;
        const value = event.target.value;
        const name = target.name;

        await this.setState({
            [name]: value
        });
        this.props.loginCallback(this.state.inputUserName, this.state.inputPassword);
    }

    render(){
        return(
            <body>
            <div className={"container"}>
                <div className={"row"}>
                    <div className={"col s6 offset-s3"}>
                        <div className={"card light-blue lighten-4"}>
                            <div className={"card-content black-text"}>
                                <span className={"card-title"}>Login</span>
                                <div className={"input-field"}>
                                    <label>Username</label>
                                    <input type="text" name="inputUserName" className={"validate"} onChange={this.handleInputChange} value={this.state.inputUserName}/>
                                </div>
                                <div className={"input-field"}>
                                    <label>Password</label>
                                    <input type="password" name="inputPassword" className={"validate"} onChange={this.handleInputChange} value={this.state.inputPassword}/>
                                </div>
                                <div>
                                    <p>{this.state.loginStatus}</p>
                                </div>
                            </div>
                            <div className={"card-action"}>
                                <a className={"waves-effect waves-light btn light-blue lighten-3"} onClick={this.onClickWrapperMethod}>Login</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            </body>
        );
    }
}