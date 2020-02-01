import React from 'react'
import { Tab, Tabs, TabList, TabPanel } from 'react-tabs';
import 'react-tabs/style/react-tabs.css';
import {PersonalInput} from "./PersonalInput";
import {Results} from "./Results"
import {Login} from "./Login"
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
            outputIden: null,
            loginOutput: null,
            bearerToken:null,
            userName: null,
            password: null
        };
        //React Binding because of nebulous this references
        this.personalCallback = this.personalCallback.bind(this);
        this.sendPortfolio = this.sendPortfolio.bind(this);
        this.loginCallback = this.loginCallback.bind(this);
        this.sendLogin = this.sendLogin.bind(this);
    }
    
    //A group of callback functions, one passed into its corresponding subcomponent,
    // to allow the subcomponent to send data back to the parent component.
    
    personalCallback(firstName, middleName, lastName, honorific, emailAddress){
        this.setState({firstName: firstName, middleName: middleName, lastName: lastName, honorific: honorific, emailAddress: emailAddress});
    }
    
    loginCallback(userName, password, bearerToken){
        this.setState({userName: userName, password: password, bearerToken: bearerToken});
    }
    
    //Here we take the pulled list of assets from each child component along with the personal data,
    //turn it into JSON, and send a Http request formatted for the Controller to understand. 
    //The response is a JSON object that contains the personal data and a list of revised assets from Cheetah
    sendPortfolio(event) {
        event.preventDefault();
        fetch('api/Puma/PostAssets', {
            method: 'POST',
            headers: {
                'jwt' : this.state.bearerToken,
                'Accept': 'application/json',
                'Content-Type': 'application/json; charset=UTF-8',
            },
            body: JSON.stringify([{
                AssetIdentifier:
                    {
                        AssetCode: this.state.firstName,
                        Symbol: this.state.middleName,
                        Issue: this.state.lastName,
                        Issuer: this.state.honorific
                    },
                    Units: parseInt(this.state.emailAddress, 10)
            }])
        }).then(response => response.json())
            .then(data => {
                this.setState({outputIden: data});
            });
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
                this.loginPopup(data);
            });
    }
    
    loginPopup(resp){
        if (resp === "badLogin")
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
                        <PersonalInput personalCallback={this.personalCallback}/>
                    </TabPanel>
                    <TabPanel>
                        <Results outputIden={this.state.outputIden} sendPortfolio={this.sendPortfolio}/>
                    </TabPanel>
                </Tabs>
            </div>
        );
    }
}
