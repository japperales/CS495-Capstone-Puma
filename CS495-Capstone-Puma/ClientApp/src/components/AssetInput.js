import {TokenContext} from "../Contexts/TokenContext.js";
import React from 'react';
import  './css/PersonalInput.css'
import M from 'materialize-css';
import Popup from "reactjs-popup";
import Autosuggest from 'react-autosuggest';

let allAssets = [];

getRequest("none")
    .then( value => {
    allAssets = value;
});

const getSuggestions = value => {
    const inputValue = value.trim().toLowerCase();
    const inputLength = inputValue.length;
    console.log(allAssets);

    return inputLength === 0 ? [] : allAssets.filter(asset =>
        asset.value.Symbol.toLowerCase().slice(0, inputLength) === inputValue
    );
};

async function getRequest(value){
    const allAssetsResponse = await fetch('api/Puma/AutoFill?value=none', {method: 'GET'});
    const json = await allAssetsResponse.json();
    console.log(json);
    return json;
}

const getSuggestionValue = suggestion => suggestion.value.Issuer;

const renderSuggestion = suggestion => (
    <div>
        {suggestion.value.Issuer}
    </div>
);

let state = {
    inputAssetCode: null,
    inputSymbol: null,
    inputIssue: null,
    inputIssuer: null,
    inputUnits: null,
    inputValue: null,
    popupOpen: false,
    suggestions: [],
    value: ""
};

export class AssetInput extends React.Component{

    static contextType = TokenContext;
    
    componentDidMount(){
        M.AutoInit();
        M.updateTextFields();
    }

    constructor(props){
        super(props);
        this.state = state;
        this.handleInputChange = this.handleInputChange.bind(this);
        this.submitAsset = this.submitAsset.bind(this);
        this.addCashToPortfolio = this.addCashToPortfolio.bind(this);
        this.openModal = this.openModal.bind(this);
        this.closeModal = this.closeModal.bind(this);
        this.onSuggestionsClearRequested = this.onSuggestionsClearRequested.bind(this);
        this.onSuggestionsFetchRequested = this.onSuggestionsFetchRequested.bind(this);
        this.onSuggestionSelected = this.onSuggestionSelected.bind(this);
        this.onChange = this.onChange.bind(this);
    }
    
    onChange = (event, {newValue}) => {
        this.setState({
            value: newValue
        })
    };
    
    onSuggestionsFetchRequested = ({value}) => {
        this.setState({
            suggestions: getSuggestions(value)
        });
    };
    
    onSuggestionsClearRequested = () => {
        this.setState({
            suggestions: []
        });
        M.updateTextFields();
    };

    async onSuggestionSelected(event, suggestionValue){
        const asset = suggestionValue.suggestion;
        this.setState({inputIssuer: asset.value.Issuer, inputSymbol: asset.value.Symbol, inputAssetCode: asset.value.AssetCode, inputIssue: asset.value.Issue});
        await M.updateTextFields();
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
       
        M.updateTextFields();
    }
    
    //method for the submission of the input field values to the backend to find an asse3t that matches.
    // If a match is found, the asset is added to the current portfolio. If no match is found, the cash substitution popup is shown
    submitAsset(event){
        
        event.preventDefault();
        let token = this.context;
        if (this.context !== null) {
            fetch('api/Puma/ValidateAsset', {
                method: 'POST',
                headers: {
                    'jwt': this.context.Jwt,
                    'Accept': 'application/json',
                    'Content-Type': 'application/json; charset=UTF-8',
                },
                body: JSON.stringify({
                    id: null,
                    value:
                        {
                            AssetCode: this.state.inputAssetCode,
                            Symbol: this.state.inputSymbol,
                            Issue: this.state.inputIssue,
                            Issuer: this.state.inputIssuer
                        }
                    
                })
            }).then(response => response.json())
                .then(data => {
                    if (data !== null) {
                        const newAsset = {
                            assetId: data.id,
                            assetCode: data.value.AssetCode,
                            symbol: data.value.Symbol,
                            issue: data.value.Issue,
                            issuer: data.value.Issuer,
                            units: this.state.inputUnits,
                            pricePerShare: data.pricePerShare,
                            totalValue: (data.pricePerShare * this.state.inputUnits),
                            assetCategoryName: data.assetCategory
                        };
                        console.log(data.assetCategory);
                        const copyOfCurrentPortfolio = [...this.props.currentPortfolio];
                        copyOfCurrentPortfolio.push(newAsset);
                        this.props.modifyPortfolio(copyOfCurrentPortfolio);
                    }else{
                        this.openModal();
                    }
                });
        }
        
    }

    
    //Behaviors for Cash popup, if no asset match is found in when submitAsset() is called, the popup is shown
    addCashToPortfolio(event){
        event.preventDefault();
        const copyOfCurrentPortfolio = [...this.props.currentPortfolio];
        copyOfCurrentPortfolio.push({assetId: 1, assetCode: "Cash", symbol: "CSH", issue: "Fed Service", issuer: "Fed", 
            units: this.state.inputValue, assetCategoryName: "Money Market", pricePerShare: 1, totalValue:  this.state.inputValue});
        this.props.modifyPortfolio(copyOfCurrentPortfolio);
        this.closeModal();
    }
    
    openModal() {
        this.setState({ popupOpen: true });
    }
    
    closeModal() {
        this.setState({ popupOpen: false });
    }

    render(){
        const { value, suggestions } = this.state;
        
        const inputProps = {
            value,
            onChange: this.onChange
        };
        
        return(
            <div className={"card light-blue lighten-4"}>
                <div className={"card-content black-text"}>
                    <h3>Input Assets </h3>
                <br />
                    <h4>Enter Asset Identifiers in one of two ways:</h4>
                <br />
                    <h5>Type in asset names below for autosuggest values to appear.</h5>
                    <h5>Click on the suggestion to select it.</h5>
                <br />
                    <label>Enter Value for Autofill Suggestions</label>
                    <Autosuggest
                        suggestions={suggestions}
                        onSuggestionsFetchRequested={this.onSuggestionsFetchRequested}
                        onSuggestionsClearRequested={this.onSuggestionsClearRequested}
                        getSuggestionValue={getSuggestionValue}
                        renderSuggestion={renderSuggestion}
                        onSuggestionSelected={this.onSuggestionSelected}
                        inputProps={inputProps}
                    />
                    <h5>Input asset code and symbol for Stocks, Mutual Funds, etc:</h5>
                    <div className={"input-field"}>
                        <label>Asset Code</label>
                        <input type="text" name="inputAssetCode" className={"validate"} onChange={this.handleInputChange} value={this.state.inputAssetCode}/>
                    </div>
                    <div className={"input-field"}>
                        <label>Symbol</label>
                        <input type="text" name="inputSymbol" className={"validate"} onChange={this.handleInputChange} value={this.state.inputSymbol}/>
                    </div>
                <br />
                    <h4>OR</h4>
                <br />
                    <h5>Input issue and issuer for loans, money markets, etc.</h5>
                <br />
                    <div className={"input-field"}>
                        <label>Issue</label>
                        <input type="text" name="inputIssue" className={"validate"} onChange={this.handleInputChange} value={this.state.inputIssue}/>
                    </div>
                    <div className={"input-field"}>
                        <label>Issuer</label>
                        <input type="text" name="inputIssuer" className={"validate"} onChange={this.handleInputChange} value={this.state.inputIssuer}/>
                    </div>
                <br />
                    <h4>Enter Asset Quantity and Total Value:</h4>
                <br />
                    <div className={"input-field"}>
                        <label>Asset Quantity</label>
                        <input type="number" name="inputUnits" className={"validate"} onChange={this.handleInputChange} value={this.state.inputUnits}/>
                    </div>
                    <div className={"input-field"}>
                        <label>Total Value</label>
                        <input type="number" name="inputValue" className={"validate"} onChange={this.handleInputChange} value={this.state.inputValue}/>
                    </div>
                <br />
                    <div>
                        <a className={"waves-effect waves-light btn light-blue lighten-3"} onClick={this.submitAsset}>Add Asset</a>
                    </div>
                </div>
                <Popup
                    open={this.state.popupOpen}
                    closeOnDocumentClick
                    onClose={this.closeModal}
                >
                    <div className="modal">
                        <a className="close" onClick={this.closeModal}>
                            &times;
                        </a>

                    </div>
                    <text> The asset you have submitted doesn't appear to be in our database, add the cash value of the asset to the portfolio instead?</text>
                    <br/>
                    <a className={"waves-effect waves-light btn light-blue lighten-3"} onClick={this.addCashToPortfolio}>Add Cash Value</a>
                    <text>   </text><a className={"waves-effect waves-light btn light-blue lighten-3"} onClick={this.closeModal}>Cancel</a>
                </Popup>
            </div>
        );
    }
}
