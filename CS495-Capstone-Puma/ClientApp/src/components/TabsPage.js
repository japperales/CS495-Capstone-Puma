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
            
            loginOutput: null,
            bearerToken:null,
            userName: null,
            password: null,
            portfolioResponse: null
        };
        //React Binding because of nebulous this references
        this.assetCallback = this.assetCallback.bind(this);
        this.sendPortfolio = this.sendPortfolio.bind(this);
        this.loginCallback = this.loginCallback.bind(this);
        this.sendLogin = this.sendLogin.bind(this);
        this.loginPopup = this.loginPopup.bind(this);
    }
    
    //A group of callback functions, one passed into its corresponding subcomponent,
    // to allow the subcomponent to send data back to the parent component.
    
    assetCallback(assetCode, symbol, issue, issuer, units){
        this.setState({assetCode: assetCode, symbol: symbol, issue: issue, issuer: issuer, units: units});
    }
    
    loginCallback(userName, password, bearerToken){
        this.setState({userName: userName, password: password, bearerToken: bearerToken});
    }
    
    //Here we take the pulled list of assets from each child component along with the personal data,
    //turn it into JSON, and send a Http request formatted for the Controller to understand. 
    //The response is a JSON object that contains the personal data and a list of revised assets from Cheetah
    sendPortfolio(event) {
        if (this.state.bearerToken !== null) {
            event.preventDefault();
            fetch('api/Puma/PostAssets', {
                method: 'POST',
                headers: {
                    'jwt': this.state.bearerToken.Jwt,
                    'Accept': 'application/json',
                    'Content-Type': 'application/json; charset=UTF-8',
                },
                body: JSON.stringify([{
                    AssetIdentifier:
                        {
                            AssetCode: this.state.assetCode,
                            Symbol: this.state.symbol,
                            Issue: this.state.issue,
                            Issuer: this.state.issuer
                        },
                    Units: parseInt(this.state.units, 10)
                }])
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
                this.setState({bearerToken: data});
                this.loginPopup(this.state.bearerToken.WasSuccessful);
            });
    }
    
    loginPopup(wasSuccessful){
        if (wasSuccessful)
        {
            window.alert("Login Failed.\nCheck your credentials.")
        }
        else {
            window.alert("Login Successful.\nProceed to Input Data Page.")
        }
    }
    
    //Each Tab in the TabsList navigates to a corresponding TabPanel
    render() {
        return(
            <div>
                <text>{JSON.stringify(this.state.bearerToken)}</text>
                <Tabs>
                    <TabList>
                        <Tab>Login</Tab>
                        <Tab>Input Data</Tab>
                        <Tab>Results</Tab>
                    </TabList>

                    <TabPanel>
                        <Login bearerToken={this.state.bearerToken} onChange={this.handleInputChange} sendLogin={this.sendLogin} loginCallback={this.loginCallback}/>
                    </TabPanel>
                    <TabPanel>
                        <AssetInput assetCallback={this.assetCallback}/>
                    </TabPanel>
                    <TabPanel>
                        <Results portfolioResponse={this.state.portfolioResponse} sendPortfolio={this.sendPortfolio}/>
                    </TabPanel>
                </Tabs>
            </div>
        );
    }
}
