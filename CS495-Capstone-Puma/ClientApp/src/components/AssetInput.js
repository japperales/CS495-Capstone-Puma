import EditableTable from "./EditableTable";
﻿import React from 'react';
import  './css/PersonalInput.css'
import M from 'materialize-css'
import {portfolioColumns} from "./TableColumns";

let state = {
    inputAssetCode: null,
    inputSymbol: null,
    inputIssue: null,
    inputIssuer: null,
    inputUnits: null
};

export class AssetInput extends React.Component{
    componentDidMount(){
        console.log("component did mount");
        M.AutoInit();
        console.log("Current Portfolio is: " + this.props.currentPortfolio)
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
                    <h3>Input</h3>
                    <br />
                    <EditableTable title={"Current Portfolio"} columns={portfolioColumns} data={this.props.currentPortfolio} setParentData={this.props.assetCallback}/>
                </div>
            </div>
        );
    }

}