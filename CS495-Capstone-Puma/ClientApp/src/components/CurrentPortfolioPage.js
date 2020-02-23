import {AssetInput} from "./AssetInput";
﻿import React from 'react';
import  './css/PersonalInput.css'
import M from 'materialize-css'
import {portfolioColumns} from "./TableColumns";
import DeleteableTable from "./DeleteableTable";
import {Doughnut} from "react-chartjs-2";




let state = {
    inputAssetCode: null,
    inputSymbol: null,
    inputIssue: null,
    inputIssuer: null,
    inputUnits: null
};

export class CurrentPortfolioPage extends React.Component{
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
                <h3>Current Portfolio</h3>
                    <div className="row">
                        <div className="col s6">
                            <AssetInput addAsset={this.props.assetCallback} />
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
                                    data: [10,20,30],
                                    backgroundColor: [
                                        '#008080',
                                        '#1AE6E6',
                                        '#66FFFF',
                                        '#B2FFFF',
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
                        </div>
                    </div>    
                    
            
            </div>
        );
    }

}
//<EditableTable title={"Current Portfolio"} columns={portfolioColumns} data={this.props.currentPortfolio} setParentData={this.props.assetCallback}/>