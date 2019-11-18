import React from 'react'
import { Tab, Tabs, TabList, TabPanel } from 'react-tabs';
import 'react-tabs/style/react-tabs.css';
import {PersonalInput} from "./PersonalInput";
import {AccountHistoryInput} from "./AccountHistoryInput";
import {AssetsInput} from "./AssetsInput";
import {BondInput} from "./BondInput";
import {MiscAssetInput} from "./MiscAssetInput";
import {LoanInput} from "./LoanInput";
import {MutualFundInput} from "./MutualFundInput";
import {StockInput} from "./StockInput";
import {Propertyinput} from "./Propertyinput";
import {Results} from "./Results";

export class TabsPage extends React.Component {
    
    constructor(props){
        super(props);
        this.state = {
            firstName: null,
            middleName: null,
            lastName: null,
            honorific: null,
            emailAddress: null,
            
            outputFirstName: null,
            outputMiddleName: null,
            outputLastName: null,
            outputHonorific: null,
            outputEmailAddress: null,
            
            bonds:[],
            misc:[],
            loans: [],
            mutualFunds: [],
            stocks: [],
            properties: []
        };
        this.personalCallback = this.personalCallback.bind(this);
        this.bondCallback = this.bondCallback.bind(this);
        this.miscCallback = this.miscCallback.bind(this);
        this.loanCallback = this.loanCallback.bind(this);
        this.mutualFundCallback = this.mutualFundCallback.bind(this);
        this.stockCallback = this.stockCallback.bind(this);
        this.propertyCallback = this.propertyCallback.bind(this);
        
        this.sendPortfolio = this.sendPortfolio.bind(this);
    }
    
    personalCallback(firstName, middleName, lastName, honorific, emailAddress){
        this.setState({firstName: firstName, middleName: middleName, lastName: lastName, honorific: honorific, emailAddress: emailAddress});
        
    }
    
    bondCallback(assets){
        this.setState({bonds: assets});
    }
    
    miscCallback(assets){
        this.setState({misc: assets});
    }
    
    loanCallback(assets){
        this.setState({loans: assets});
    }
    
    mutualFundCallback(assets){
        this.setState({mutualFunds: assets});
    }
    
    stockCallback(assets){
        this.setState({stocks: assets});
    }
    
    propertyCallback(assets){
        this.setState({properties: assets});
    }
    
    sendPortfolio(event) {
        event.preventDefault();
        fetch('api/Puma/SendAndReceivePortfolio', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json; charset=UTF-8',
            },
            body: JSON.stringify({

                IdentityRecord: {
                    firstName: this.state.firstName,
                    middleName: this.state.middleName,
                    lastName: this.state.lastName,
                    honorific: this.state.honorific,
                    emailAddress: this.state.emailAddress,
                },
                BondList: this.state.bonds,
                MiscList: this.state.misc,
                LoanList: this.state.loans,
                MutualFundList: this.state.mutualFunds,
                StockList: this.state.stocks,
                PropertyList: this.state.properties
                
            })
        }).then(response => response.json())
            .then(data => {
                this.setState({ outputFirstName: data.firstName, outputMiddleName: data.middleName, outputLastName: data.lastName, outputHonorific : data.honorific, outputEmailAddress: data.emailAddress});
            });
        
    }
    
    render() {
        return(
            <div>
                <Tabs>
                    <TabList>
                        <Tab>Personal Info</Tab>
                        <Tab>Bonds</Tab>
                        <Tab>Miscellaneous Assets</Tab>
                        <Tab>Loans</Tab>
                        <Tab>Mutual Funds</Tab>
                        <Tab>Stocks</Tab>
                        <Tab>Properties</Tab>
                        <Tab>simple-results-tab</Tab>
                        <Tab>Results</Tab>

                    </TabList>

                    <TabPanel>
                        <PersonalInput personalCallback={this.personalCallback}/>
                    </TabPanel>
                    <TabPanel>
                        <BondInput bondCallback={this.bondCallback}/>
                    </TabPanel>
                    <TabPanel>
                        <MiscAssetInput miscCallback={this.miscCallback}/>
                    </TabPanel>
                    <TabPanel>
                        <LoanInput loanCallback={this.loanCallback}/>
                    </TabPanel>
                    <TabPanel>
                        <MutualFundInput mutualFundCallback={this.mutualFundCallback}/>
                    </TabPanel>
                    <TabPanel>
                        <StockInput stockCallback={this.stockCallback}/>
                    </TabPanel>
                    <TabPanel>
                        <Propertyinput propertyCallback={this.propertyCallback}/>
                    </TabPanel>
                    <TabPanel>
                        <Results />
                    </TabPanel>
                </Tabs>
                <button onClick={this.sendPortfolio}>Submit Info</button>
                Here is my example of props and callbacks: currently, the first name is: {this.state.firstName}, the middle name is: {this.state.middleName}, the last name is: {this.state.lastName}, the honorific is: {this.state.honorific}, the email is: {this.state.emailAddress}
            <br/> OUTPUT: {this.state.outputFirstName}, <br/>
                <br/>{this.state.outputMiddleName},
                <br/>{this.state.outputLastName}, {this.state.outputHonorific}, {this.state.outputEmailAddress}
                <br/><br/>BONDS: {JSON.stringify(this.state.bonds)},
                <br/><br/>MISC: {JSON.stringify(this.state.misc)},
                <br/><br/>LOANS: {JSON.stringify(this.state.loans)},
                <br/><br/>MUTUAL FUNDS: {JSON.stringify(this.state.mutualFunds)},

                <br/><br/>STOCKS: {JSON.stringify(this.state.stocks)},
                <br/><br/>PROPERTIES: {JSON.stringify(this.state.properties)}
            </div>
        );
    }
}
