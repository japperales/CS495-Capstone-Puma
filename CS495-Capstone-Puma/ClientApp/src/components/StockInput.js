import React from 'react'
import M from 'materialize-css'

let state = {
    assets: [],
    inputName: null,
    inputPrice: null,
    inputQuantity: null,
    inputExchangeType: null,
    inputEarningsPerShareDiluted: null,
    inputEarningPerShareBasic: null,
    inputEarningsPerShareEffectiveDate: null,
    inputPaymentFrequencyType: null,
    inputSharesOutstanding: null,
    inputIsIncludedIn13F: null,
    inputIsRestrictedByRule144A: null,
    inputCalculatedMarketCapType: null
};

export class StockInput extends React.Component{
    
    componentDidMount(){
        console.log("component did mount")
        M.AutoInit();
    }

    constructor(props) {
        super(props);
        this.state = state;
        
        this.addAsset = this.addAsset.bind(this);
        this.removeAsset = this.removeAsset.bind(this);
        this.handleInputChange = this.handleInputChange.bind(this);
    }

    componentWillUnmount() {
        state = this.state;
    }

    renderTableHeader() {
        if(this.state.assets.length>0) {
            let header = Object.keys(this.state.assets[0]);
            return header.map((key, index) => {
                return <th key={index}>{key.toUpperCase()}</th>
            })
        }    
    }

    renderTableData() {
        return this.state.assets.map((asset, index) => {
            const { name, price, quantity, exchangeType, earningsPerShareDiluted, earningsPerShareBasic, 
                earningsPerShareEffectiveDate, paymentFrequencyType, sharesOutstanding, isIncludedIn13F, 
                isRestrictedByRule144A, calculatedMarketCapType} = asset;
            return (
                <tr key={name}>
                    <td>{name}</td>
                    <td>{price}</td>
                    <td>{quantity}</td>
                    <td>{exchangeType}</td>
                    <td>{earningsPerShareDiluted}</td>
                    <td>{earningsPerShareBasic}</td>
                    <td>{earningsPerShareEffectiveDate}</td>
                    <td>{paymentFrequencyType}</td>
                    <td>{sharesOutstanding}</td>
                    <td>{isIncludedIn13F}</td>
                    <td>{isRestrictedByRule144A}</td>
                    <td>{calculatedMarketCapType}</td>
                </tr>
            )
        })
    }

    handleInputChange(event){

        const target = event.target;
        const value = event.target.value;
        const name = target.name;

        this.setState({
            [name]: value
        });

    }

    async addAsset(event){
        event.preventDefault();
        const newAsset = {
            name: this.state.inputName,
            price: this.state.inputPrice,
            quantity: this.state.inputQuantity,
            exchangeType: this.state.inputExchangeType,
            earningsPerShareDiluted: this.state.inputEarningsPerShareDiluted,
            earningsPerShareBasic: this.state.inputEarningPerShareBasic,
            earningsPerShareEffectiveDate: this.state.inputEarningsPerShareEffectiveDate,
            paymentFrequencyType: this.state.inputPaymentFrequencyType,
            sharesOutstanding: this.state.inputSharesOutstanding,
            isIncludedIn13F: this.state.inputIsIncludedIn13F,
            isRestrictedByRule144A: this.state.inputIsRestrictedByRule144A,
            calculatedMarketCapType: this.state.inputCalculatedMarketCapType
            
        };
        await this.setState({assets: this.state.assets.concat(newAsset)});
        this.props.stockCallback(this.state.assets);
    }

    async removeAsset(){
        await this.setState({asset: this.state.assets.pop()});
        this.props.stockCallback(this.state.assets);
    }

    render(){
        return(
            <div>
                <h3 id='title'>Stocks</h3>
                <table className='table' id='assets'>
                    <tbody>
                    <tr>{this.renderTableHeader()}</tr>
                    {this.renderTableData()}
                    </tbody>
                </table>
                <form onSubmit={this.addAsset}>
                    
                <div className="center-align">
                    <div className = "input-field col s6">    
                        <label>Name</label>
                        <input type="text" name="inputName" required onChange={this.handleInputChange} value={this.state.inputName}/>
                    </div>
                </div>
                
                <div className="center-align">
                    <div className = "input-field col s6">    
                        <label>Price</label>
                        <input type="number" name="inputPrice" required onChange={this.handleInputChange} value={this.state.inputPrice}/>
                    </div>
                </div>
                
                <div className="center-align">
                    <div className = "input-field col s6">    
                        <label>Quantity</label>
                        <input type="number" name="inputQuantity" required onChange={this.handleInputChange} value={this.state.inputQuantity}/>
                    </div>
                </div>
                
                <div className="center-align">
                    <div className = "input-field col s6">
                        <label>ExchangeType</label>
                        <input type="text" name="inputExchangeType" required onChange={this.handleInputChange} value={this.state.inputExchangeType}/>
                    </div>
                </div>
                
                <div className="center-align">
                    <div className = "input-field col s6">    
                        <label>EarningsPerShareDiluted</label>
                        <input type="number" name="inputEarningsPerShareDiluted" required onChange={this.handleInputChange} value={this.state.inputEarningsPerShareDiluted}/>
                    </div>
                </div>
                
                <div className="center-align">
                    <div className = "input-field col s6">    
                        <label>EarningPerShareBasic</label>
                        <input type="number" name="inputEarningPerShareBasic" required onChange={this.handleInputChange} value={this.state.inputEarningPerShareBasic}/>
                    </div>
                </div>
                
                <div className="center-align">
                    <div className = "input-field col s6">    
                        <label>EarningsPerShareEffectiveDate</label>
                        <input type="text" className="datepicker" name="inputEarningsPerShareEffectiveDate" required onChange={this.handleInputChange} value={this.state.inputEarningsPerShareEffectiveDate}/>
                    </div>
                </div>
                
                <div className="center-align">
                    <div className = "input-field col s6">    
                        <label>PaymentFrequencyType</label>
                        <input type="text" name="inputPaymentFrequencyType" required onChange={this.handleInputChange} value={this.state.inputPaymentFrequencyType}/>
                    </div>
                </div>
                
                <div className="center-align">
                    <div className = "input-field col s6">    
                        <label>SharesOutstanding</label>
                        <input type="number" name="inputSharesOutstanding" required onChange={this.handleInputChange} value={this.state.inputSharesOutstanding}/>
                    </div>
                </div>
                
                <div className="center-align">
                    <div className = "input-field col s6">    
                        <label>IsIncludedIn13F</label>
                        <select name="inputIsIncludedIn13F" required onChange={this.handleInputChange}  value={this.state.inputIsIncludedIn13F}>
                            <option value="true" >true</option>
                            <option value="false" >false</option>
                            <option value="null" selected="selected"> </option>
                        </select>
                    </div>
                </div>
                
                <div className="center-align">
                    <div className = "input-field col s6">    
                        <label>IsRestrictedByRule144A</label>
                        <select name="inputIsRestrictedByRule144A" required onChange={this.handleInputChange} value={this.state.inputIsRestrictedByRule144A}>
                            <option value="true" >true</option>
                            <option value="false" >false</option>
                            <option value="null" selected="selected"> </option>
                        </select>
                    </div>
                </div>
                
                <div className="center-align">
                    <div className = "input-field col s6">    
                        <label>CalculatedMarketCapType</label>
                        <input type="text" name="inputCalculatedMarketCapType" required onChange={this.handleInputChange} value={this.state.inputCalculatedMarketCapType}/>
                    </div>
                </div>
                    
                    <input type="submit" value="Add Asset" className="waves-effect waves-light btn-small"/>
                </form>
                <a onClick={this.removeAsset} className="waves-effect waves-light btn-small">Remove Asset</a>
                <br/>
                <br/>
            </div>
        );
    }

}