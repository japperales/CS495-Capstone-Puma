import React from 'react'
import { Tab, Tabs, TabList, TabPanel } from 'react-tabs';
import 'react-tabs/style/react-tabs.css';
import {Results} from "./Results"
import {Login} from "./Login"
import  './css/TabsPage.css'
import {AssetInput} from "./AssetInput";
export class TabsPage extends React.Component {

    constructor(props){
        super(props);
        this.state = {
            assetCode: null,
            symbol: null,
            issue: null,
            issuer: null,
            units: null,
            totalValue: null,
            
            loginOutput: null,
            bearerToken:null,
            userName: null,
            password: null,
            portfolioResponse: null,
            currentPortfolio: []
        };
        //React Binding because of nebulous this references
        this.assetCallback = this.assetCallback.bind(this);
        this.sendPortfolio = this.sendPortfolio.bind(this);
        this.loginCallback = this.loginCallback.bind(this);
        this.sendLogin = this.sendLogin.bind(this);
        this.loginPopup = this.loginPopup.bind(this);
        this.formatPortfolioToSend = this.formatPortfolioToSend.bind(this);
    }
    
    //A group of callback functions, one passed into its corresponding subcomponent,
    // to allow the subcomponent to send data back to the parent component.
    
    assetCallback(newCurrentPortfolio){
        this.setState({currentPortfolio: newCurrentPortfolio});
    }
    
    loginCallback(userName, password){
        this.setState({userName: userName, password: password});
    }
    
    //Here we take the pulled list of assets from each child component along with the personal data,
    //turn it into JSON, and send a Http request formatted for the Controller to understand. 
    //The response is a JSON object that contains the personal data and a list of revised assets from Cheetah
    sendPortfolio(event) {
        const formattedPortfolio = this.formatPortfolioToSend();
        if (this.state.bearerToken !== null) {
            event.preventDefault();
            fetch('api/Puma/PostAssets', {
                method: 'POST',
                headers: {
                    'jwt': this.state.bearerToken.Jwt,
                    'Accept': 'application/json',
                    'Content-Type': 'application/json; charset=UTF-8',
                },
                body: JSON.stringify(formattedPortfolio)
            }).then(response => response.json())
                .then(data => {
                    this.setState({portfolioResponse: data});
                });
        }
    }
    
    sendLogin(event) {
        event.preventDefault();
        fetch('api/Puma/PostLogin', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json; charset=UTF-8',
            },
            body: JSON.stringify({
                username: this.state.userName,
                password: this.state.password
            })})
            .then(response => response.json())
            .then(data => {
                if(data.wasSuccessful) {
                    this.setState({bearerToken: data});
                }
                this.loginPopup(data.wasSuccessful);
            });
    }
    
    loginPopup(wasSuccessful){
        if (wasSuccessful)
        {
            window.alert("Login Successful.\nProceed to Input Data Page.");
        }
        else {
            window.alert("Login Failed.\nCheck your credentials.");
        }
    }
    
    formatPortfolioToSend(){
        const formattedPortfolio = [];
            
        for(let asset in this.state.currentPortfolio){
            const formattedAsset = {
                AssetIdentifier:
                    {
                        AssetCode: asset.assetCode,
                        Symbol: asset.symbol,
                        Issue: asset.issue,
                        Issuer: asset.issuer
                    },
                Units: parseInt(asset.units, 10)
            };
            formattedPortfolio.push(formattedAsset);
        }
        console.log("Formatted Portfolio is: " + formattedPortfolio);
        return formattedPortfolio;
    }
    
    //Each Tab in the TabsList navigates to a corresponding TabPanel
    render() {
        return(
            <div>
                <text>{JSON.stringify(this.state.currentPortfolio)}</text>
                <Tabs>
                    <TabList>
                        <Tab>Login</Tab>
                        <Tab>Input Data</Tab>
                        <Tab>Results</Tab>
                    </TabList>

                    <TabPanel>
                        <Login bearerToken={this.state.bearerToken} sendLogin={this.sendLogin} loginCallback={this.loginCallback}/>
                    </TabPanel>
                    <TabPanel>
                        <AssetInput assetCallback={this.assetCallback} currentPortfolio={this.state.currentPortfolio} />
                    </TabPanel>
                    <TabPanel>
                        <Results portfolioResponse={this.state.portfolioResponse} sendPortfolio={this.sendPortfolio}/>
                    </TabPanel>
                </Tabs>
            </div>
        );
    }
}
