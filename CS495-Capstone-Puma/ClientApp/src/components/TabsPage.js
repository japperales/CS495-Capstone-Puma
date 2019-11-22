import React from 'react'
import { Tab, Tabs, TabList, TabPanel } from 'react-tabs';
import 'react-tabs/style/react-tabs.css';
import {PersonalInput} from "./PersonalInput";
import {BondInput} from "./BondInput";
import {MiscAssetInput} from "./MiscAssetInput";
import {LoanInput} from "./LoanInput";
import {MutualFundInput} from "./MutualFundInput";
import {StockInput} from "./StockInput";
import {Propertyinput} from "./Propertyinput";
import {Results} from "./Results"

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
            properties: [],
            outputIden: null                  
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
        fetch('api/Puma', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json; charset=UTF-8',
            },
            body: JSON.stringify({
                IdentityRecord: {
                    firstNameLegalName: this.state.firstName,
                    middleName: this.state.middleName,
                    lastName: this.state.lastName,
                    salutationType: this.state.honorific,
                    emails: [{emailAddress: this.state.emailAddress}],
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
                this.setState({outputIden: data});
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
                        <Results outputIden={this.state.outputIden}/>
                    </TabPanel>
                </Tabs>
                <button onClick={this.sendPortfolio}>Submit Info</button>
            </div>
        );
    }
}
