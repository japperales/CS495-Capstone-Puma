import {AssetInput} from "./AssetInput";
﻿import React from 'react';
import  './css/PersonalInput.css'
import M from 'materialize-css'
import {portfolioColumns} from "./TableColumns";
import DeleteableTable from "./DeleteableTable";
import {Doughnut} from "react-chartjs-2";
import {TokenContext} from "../Contexts/TokenContext";

let state = {
    inputAssetCode: null,
    inputSymbol: null,
    inputIssue: null,
    inputIssuer: null,
    inputUnits: null,
    currentPortfolio: [],
    accountResponse: "Not submitted yet!"
};

export class CurrentPortfolioPage extends React.Component{
    static contextType = TokenContext;
    
    componentDidMount(){
        console.log("component did mount");
        M.AutoInit();
    }

    constructor(props){
        super(props);
        this.state = state;
        this.handleInputChange = this.handleInputChange.bind(this);
        this.assetCallback = this.assetCallback.bind(this);
        this.postAssets = this.postAssets.bind(this);
    }
    
    componentWillUnmount() {
        state = this.state;
    }
    
    assetCallback(newCurrentPortfolio){
        this.setState({currentPortfolio: newCurrentPortfolio});
    }
    
    async handleInputChange(event){

        const target = event.target;
        const value = event.target.value;
        const name = target.name;

        await this.setState({
            [name]: value
        });
        
    }
    
    postAssets(event){
        event.preventDefault();
        const submissionArray = [];
        for(let asset of this.state.currentPortfolio){
            console.log(JSON.stringify(asset));
            submissionArray.push({
                assetIdentifier: {
                    assetCode: asset.assetCode,
                    symbol: asset.symbol,
                    issue: asset.issue,
                    issuer: asset.issuer
                },
                units: asset.units
            })
        }
        console.log(this.context.Jwt);
        if (this.context !== null) {
            fetch('api/Puma/PostAssets', {
                method: 'POST',
                headers: {
                    'jwt': this.context.Jwt,
                    'Accept': 'application/json',
                    'Content-Type': 'application/json; charset=UTF-8',
                },
                body: JSON.stringify(submissionArray)
            }).then(response => response.json())
                .then((data) => {
                    console.log(JSON.stringify(data));
                this.setState({accountResponse: data});
                window.alert("Portfolio Submitted")
            });
        }
    }
    
    render(){
        let doughnutValues = [0,0,0,0];
        for (let asset of this.state.currentPortfolio){
            let index = ((this.state.currentPortfolio.indexOf(asset)%4));
            let value = asset.units;
            let sum = (parseInt(doughnutValues[index]) + parseInt(value));
            doughnutValues[index] = sum;
            
        }
        return(
            <div className="container">
                <h3>Current Portfolio</h3>
                    <div className="row">
                        <div className="col s6">
                            <AssetInput modifyPortfolio={this.assetCallback} currentPortfolio={this.state.currentPortfolio}/>
                        </div>
                        <div className="col s6">
                            <Doughnut data={{
                                labels: [
                                    'Money Markets',
                                    'Common Stock',
                                    'Mutual Funds',
                                    'Loans & Notes Receivables'
                                ],
                                datasets: [{
                                    data: doughnutValues,
                                    backgroundColor: [
                                        '#FF6384',
                                        '#36A2EB',
                                        '#FFCE56',
                                        '#66ff00',
                                    ],
                                    hoverBackgroundColor: [
                                        '#FF6384',
                                        '#36A2EB',
                                        '#FFCE56',
                                        '#66ff00'
                                    ]
                                }]}}/>
                                <br />
                            <DeleteableTable title={"Current Portfolio"} columns={portfolioColumns} data={this.state.currentPortfolio} setParentData={this.assetCallback}/>
                            <div>
                                <h3>Ready to submit your current portfolio? 
                                    Hit "Submit Portfolio" below and then <a href="https://asctrustv57.accutech-systems.net/LogOn" target="_blank">Click The Link</a> to head over to 
                                    Accutech to modify the portfolio.</h3>
                                <h3>The account number is: {this.state.accountResponse.AccountNumber}</h3>
                                <a className={"waves-effect waves-light btn light-blue lighten-3"} onClick={this.postAssets}>Submit Portfolio</a>
                            </div>
                                
                        </div>
                    </div>    
                    
            
            </div>
        );
    }

}