import React from 'react'

let state = {assets: [
        { name: 'test1', price: '45.5', quantity: 21, exchangeType: "good exchange",

            earningsPerShareDiluted: 12345, earningsPerShareBasic: 54321, earningsPerShareEffectiveDate: "04-30-1997",

            paymentFrequencyType: "nice frequency", sharesOutstanding: 45, isIncludedIn13F: "true", isRestrictedByRule144A: "false", calculatedMarketCapType: "neato cap"}
    ],
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
        let header = Object.keys(this.state.assets[0]);
        return header.map((key, index) => {
            return <th key={index}>{key.toUpperCase()}</th>
        })
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

    async addAsset(){
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
                <h3 id='title'>Assets</h3>
                <table className='table' id='assets'>
                    <tbody>
                    <tr>{this.renderTableHeader()}</tr>
                    {this.renderTableData()}
                    </tbody>
                </table>
                <label>Name</label>
                <input type="text" name="inputName" onChange={this.handleInputChange} value={this.state.inputName}/>
                <br />
                <label>Price</label>
                <input type="number" name="inputPrice" onChange={this.handleInputChange} value={this.state.inputPrice}/>
                <br />
                <label>Quantity</label>
                <input type="number" name="inputQuantity" onChange={this.handleInputChange} value={this.state.inputQuantity}/>
                <br />
                <label>ExchangeType</label>
                <input type="text" name="inputExchangeType" onChange={this.handleInputChange} value={this.state.inputExchangeType}/>
                <br />
                <label>EarningsPerShareDiluted</label>
                <input type="number" name="inputEarningsPerShareDiluted" onChange={this.handleInputChange} value={this.state.inputEarningsPerShareDiluted}/>
                <br />
                <label>EarningPerShareBasic</label>
                <input type="number" name="inputEarningPerShareBasic" onChange={this.handleInputChange} value={this.state.inputEarningPerShareBasic}/>
                <br />
                <label>EarningsPerShareEffectiveDate</label>
                <input type="date" name="inputEarningsPerShareEffectiveDate" onChange={this.handleInputChange} value={this.state.inputEarningsPerShareEffectiveDate}/>
                <br />
                <label>PaymentFrequencyType</label>
                <input type="text" name="inputPaymentFrequencyType" onChange={this.handleInputChange} value={this.state.inputPaymentFrequencyType}/>
                <br />
                <label>SharesOutstanding</label>
                <input type="number" name="inputSharesOutstanding" onChange={this.handleInputChange} value={this.state.inputSharesOutstanding}/>
                <br />
                <label>IsIncludedIn13F</label>
                <select name="inputIsIncludedIn13F" onChange={this.handleInputChange} defaultValue={"false"} value={this.state.inputIsIncludedIn13F}>
                    <option value="true">true</option>
                    <option value="false">false</option>
                </select>
                <br />
                <label>IsRestrictedByRule144A</label>
                <select name="inputIsRestrictedByRule144A" onChange={this.handleInputChange} defaultValue={"false"} value={this.state.inputIsRestrictedByRule144A}>
                    <option value="true">true</option>
                    <option value="false">false</option>
                </select>
                <br />
                <label>CalculatedMarketCapType</label>
                <input type="text" name="inputCalculatedMarketCapType" onChange={this.handleInputChange} value={this.state.inputCalculatedMarketCapType}/>
                <br />
                <button onClick={this.addAsset}>Add Asset</button>
                <button onClick={this.removeAsset}> Remove Asset</button>
                <br/>
                <br/>
            </div>
        );
    }

}