﻿import React from 'react';
import  './css/PersonalInput.css'
import M from 'materialize-css'

let state = {
    inputAssetCode: null,
    inputSymbol: null,
    inputIssue: null,
    inputIssuer: null,
    inputUnits:null
};

export class AssetInput extends React.Component{
    componentDidMount(){
        console.log("component did mount");
        M.AutoInit();
    }

    constructor(props){
        super(props);
        this.state = state;
        this.handleInputChange = this.handleInputChange.bind(this);
    }

    componentWillUnmount() {
        state = this.state;
    }

    async handleInputChange(event){

        const target = event.target;
        const value = event.target.value;
        const name = target.name;

        await this.setState({
            [name]: value
        });
        this.props.assetCallback(this.state.inputAssetCode, this.state.inputSymbol, this.state.inputIssue, this.state.inputIssuer, this.state.inputUnits);
    }

    render(){
        return(
            <div className="container">
                <div className="row">
                    <div className="col s6 offset-s3">
                    <h3>Input</h3>
                    <br />
                    <div>
                        <div className = "input-field">
                            <label>Asset Code</label>
                            <input type="text" name="inputAssetCode" onChange={this.handleInputChange} value={this.state.inputAssetCode}/>
                        </div>
                    </div>

                    <div>
                        <div className = "input-field">
                            <label>Symbol</label>
                            <input type="text" name="inputSymbol" onChange={this.handleInputChange} value={this.state.inputSymbol}/>
                        </div>
                    </div>

                    <div>
                        <div className = "input-field">
                            <label>Issue</label>
                            <input type="text" name="inputIssue" onChange={this.handleInputChange} value={this.state.inputIssue}/>
                        </div>
                    </div>

                    <div>
                        <div className = "input-field">
                            <label>Issuer</label>
                            <input type="text" name="inputIssuer" onChange={this.handleInputChange}  value={this.state.inputIssuer} />
                        </div>
                    </div>
                    <div>
                        <div className = "input-field">
                            <label>Units</label>
                            <input type="number" name="inputUnits" onChange={this.handleInputChange} value={this.state.inputUnits}/>
                        </div>
                    </div>
                    </div>
                </div>
            </div>
        );
    }

}