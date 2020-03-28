import React from 'react';
import { Tab, Tabs, TabList, TabPanel } from 'react-tabs';
import 'react-tabs/style/react-tabs.css';
import {Results} from "./Results";
import {Login} from "./Login";
import  './css/TabsPage.css';
import {CurrentPortfolioPage} from "./CurrentPortfolioPage";
import {TokenContext} from "../Contexts/TokenContext.js";
import {OcrInterface} from "./OcrInterface";

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
            currentPortfolio: [],
            loginTab: false,
            inputTab: true,
            resultTab: true,
            ocrTab: false
            
            
        };
        
        //React Binding because of nebulous this references
        this.assetCallback = this.assetCallback.bind(this);
        this.sendPortfolio = this.sendPortfolio.bind(this);
        this.loginCallback = this.loginCallback.bind(this);
        this.sendLogin = this.sendLogin.bind(this);
        this.loginPopup = this.loginPopup.bind(this);
        this.formatPortfolioToSend = this.formatPortfolioToSend.bind(this);
        this.retrievePortfolioComparison = this.retrievePortfolioComparison.bind(this);
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
        event.preventDefault();
        const formattedPortfolio = this.formatPortfolioToSend();
        
        console.log("Formatted Portfolio is: " + JSON.stringify(formattedPortfolio));
        if (this.state.bearerToken !== null) {
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
                this.setState({inputTab:false});
                this.setState({resultTab: false});
                this.setState({loginTab: true});
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
            
        for(let asset of this.state.currentPortfolio){
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

    _refreshPage() {
        console.log("this is working");
        window.location.reload();
    }
    
    retrievePortfolioComparison(event){
        event.preventDefault();

        fetch('api/Puma/RetrievePortfolioComparison', {
            method: 'GET',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json; charset=UTF-8',
                'jwt': this.state.bearerToken.Jwt
                
            }
        })
            .then(response => response.json())
            .then(data => {
                    this.setState({portfolioResponse: data});
                    console.log(this.state.portfolioResponse)
            });
    }
    //Token Context allows any child components to access the token data without passing it down explicitly
    //Each Tab in the TabsList navigates to a corresponding TabPanel
    render() {
        return(
            <TokenContext.Provider value={this.state.bearerToken}>
                <div>
                 <Tabs>
                        <TabList>
                            <Tab disabled={this.state.loginTab}>Login</Tab>
                            <Tab disabled={this.state.ocrTab}>OCR</Tab>
                            <Tab disabled={this.state.inputTab}>Input Data</Tab>
                            <Tab disabled={this.state.resultTab}>Results</Tab>
                        </TabList>

                        <TabPanel>
                            <Login bearerToken={this.state.bearerToken} sendLogin={this.sendLogin} loginCallback={this.loginCallback}/>
                        </TabPanel>
                        <TabPanel>
                            <OcrInterface assetCallback={this.assetCallback} currentPortfolio={this.state.currentPortfolio}/>
                        </TabPanel>
                        <TabPanel>
                            <CurrentPortfolioPage assetCallback={this.assetCallback} currentPortfolio={this.state.currentPortfolio} />
                        </TabPanel>
                        <TabPanel>
                            <Results portfolioResponse={this.state.portfolioResponse} sendPortfolio={this.retrievePortfolioComparison}/>
                        </TabPanel>
                </Tabs>
                    <a className={"waves-effect waves-light btn light-blue lighten-3"} onClick={this._refreshPage}>Log out</a>
            </div>
            </TokenContext.Provider>
        );
    }
}
