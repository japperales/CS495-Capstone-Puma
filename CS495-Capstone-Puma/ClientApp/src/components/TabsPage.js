import React from 'react'
import { Tab, Tabs, TabList, TabPanel } from 'react-tabs';
import 'react-tabs/style/react-tabs.css';
import {PersonalInput} from "./PersonalInput";
import {Results} from "./Results"
import  './css/TabsPage.css'
import EditableTable from "./EditableTable";
import {bondColumns, loanColumns, mutualFundColumns, stockColumns, propertyColumns, miscColumns} from './TableColumns.js'
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
        //React Binding because of nebulous this references
        this.personalCallback = this.personalCallback.bind(this);
        this.bondCallback = this.bondCallback.bind(this);
        this.miscCallback = this.miscCallback.bind(this);
        this.loanCallback = this.loanCallback.bind(this);
        this.mutualFundCallback = this.mutualFundCallback.bind(this);
        this.stockCallback = this.stockCallback.bind(this);
        this.propertyCallback = this.propertyCallback.bind(this);
        this.sendPortfolio = this.sendPortfolio.bind(this);
    }
    
    //A group of callback functions, one passed into its corresponding subcomponent,
    // to allow the subcomponent to send data back to the parent component.
    
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
        console.log(this.state.stocks);
    }

    propertyCallback(assets){
        this.setState({properties: assets});
    }
    //Here we take the pulled list of assets from each child component along with the personal data,
    //turn it into JSON, and send a Http request formatted for the Controller to understand. 
    //The response is a JSON object that contains the personal data and a list of revised assets from Cheetah
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
    //Each Tab in the TabsList navigates to a corresponding TabPanel
    render() {
        return(
            <div>
                
                <Tabs>
                    <TabList>
                        <Tab>Personal Info</Tab>
                        <Tab>Bonds</Tab>
                        <Tab>Loans</Tab>
                        <Tab>Mutual Funds</Tab>
                        <Tab>Stocks</Tab>
                        <Tab>Properties</Tab>
                        <Tab>Miscellaneous Assets</Tab>
                        <Tab>Results</Tab>
                    </TabList>

                    <TabPanel>
                        <PersonalInput personalCallback={this.personalCallback}/>
                    </TabPanel>
                    <TabPanel>
                        <h3>Bonds</h3>
                        <EditableTable columns={bondColumns} data={this.state.bonds} setParentData={this.bondCallback} />
                    </TabPanel>
                    <TabPanel>
                        <h3>Loans</h3>
                        <EditableTable columns={loanColumns} data={this.state.loans} setParentData={this.loanCallback} />
                    </TabPanel>
                    <TabPanel>
                        <h3>Mutual Funds</h3>
                        <EditableTable columns={mutualFundColumns} data={this.state.mutualFunds} setParentData={this.mutualFundCallback} />
                    </TabPanel>
                    <TabPanel>
                        <h3>Stocks</h3>
                        <EditableTable columns={stockColumns} data={this.state.stocks} setParentData={this.stockCallback} />
                    </TabPanel>
                    <TabPanel>
                        <h3>Properties</h3>
                        <EditableTable columns={propertyColumns} data={this.state.properties} setParentData={this.propertyCallback}/>
                    </TabPanel>
                    <TabPanel>
                        <h3>Miscellaneous Assets</h3>
                        <EditableTable columns={miscColumns} data={this.state.misc} setParentData={this.miscCallback} />
                    </TabPanel>
                    <TabPanel>
                        <Results outputIden={this.state.outputIden} sendPortfolio={this.sendPortfolio}/>
                    </TabPanel>
                </Tabs>
            </div>
        );
    }
}
