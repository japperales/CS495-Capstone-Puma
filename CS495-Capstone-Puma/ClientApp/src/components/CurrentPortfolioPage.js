import {AssetInput} from "./AssetInput";
﻿import React from 'react';
import  './css/PersonalInput.css'
import M from 'materialize-css'
import {portfolioColumns} from "./TableColumns";
import DeleteableTable from "./DeleteableTable";
import {Doughnut} from "react-chartjs-2";
import {TokenContext} from "../Contexts/TokenContext";
import {sumDifferentAssetTypeValues} from "./ResultsParsing";

let state = {
    inputAssetCode: null,
    inputSymbol: null,
    inputIssue: null,
    inputIssuer: null,
    inputUnits: null,
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
        this.postAssets = this.postAssets.bind(this);
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
        
    }
    
    postAssets(event){
        event.preventDefault();
        const submissionArray = [];
        //format current portfolio assets into structure the backend accepts
        for(let asset of this.props.currentPortfolio){
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
                    if(data !== null || undefined) {
                        this.setState({accountResponse: data});
                    }else{
                        this.setState({accountResponse: {AccountNumber: "Account number not available"}})
                    }
                window.alert("Portfolio Submitted")
            });
        }
    }
    
    render(){
        let doughnutValues = sumDifferentAssetTypeValues(this.props.currentPortfolio);
        
        return(
            <div className="container">
                <h3>Current Portfolio</h3>
                    <div className="row">
                        <div className="col s6">
                            <AssetInput modifyPortfolio={this.props.assetCallback} currentPortfolio={this.props.currentPortfolio}/>
                        </div>
                        <div className="col s6">
                            <Doughnut data={{
                                labels: [
                                    'Money Markets',
                                    'Common Stock',
                                    'Mutual Funds',
                                    'Loans & Notes Receivables',
                                    'Other'
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
                            <DeleteableTable title={"Current Portfolio"} columns={portfolioColumns} data={this.props.currentPortfolio} setParentData={this.props.assetCallback}/>
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