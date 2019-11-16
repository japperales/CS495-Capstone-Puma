import React from 'react'

let state = {assets: [
        { name: 'test1', price: '45.5', quantity: 21,

            incomePaymentMonth: 12345, incomePaymentDay: 54321, useDailyFactor: "false", accrualMethodType: "annually",

            exchangeType: "good exchange", earningsPerShareDiluted: 25.993, fundFamilyId: 4234234, fundCategoryId: 995, 
            
            fundNumber: 75634838, fundStatusType: "big ol' fund", shortTermRedemptionFeePercent: 2.875, shortTermHoldingPeriod: 2573}
    ],
    inputName: null,
    inputPrice: null,
    inputQuantity: null,
    inputIncomePaymentMonth: null,
    inputIncomePaymentDay: null,
    inputUseDailyFactor: null,
    inputAccrualMethodType: null,
    inputExchangeType: null,
    inputEarningsPerShareDiluted: null,
    inputFundFamilyId: null,
    inputFundCategoryId: null,
    inputFundNumber: null,
    inputFundStatusType: null,
    inputShortTermRedemptionFeePercent: null,
    inputShortTermHoldingPeriod: null
};

export class MutualFundInput extends React.Component{

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
            const { name, price, quantity, incomePaymentMonth, 
                
                incomePaymentDay, useDailyFactor, accrualMethodType, 
                
                exchangeType, earningsPerShareDiluted, fundFamilyId, 
                
                fundCategoryId, fundNumber, fundStatusType, 
                
                shortTermRedemptionFeePercent, shortTermHoldingPeriod} = asset;
            return (
                <tr key={name}>
                    <td>{name}</td>
                    <td>{price}</td>
                    <td>{quantity}</td>
                    <td>{incomePaymentMonth}</td>
                    <td>{incomePaymentDay}</td>
                    <td>{useDailyFactor}</td>
                    <td>{accrualMethodType}</td>
                    <td>{exchangeType}</td>
                    <td>{earningsPerShareDiluted}</td>
                    <td>{fundFamilyId}</td>
                    <td>{fundCategoryId}</td>
                    <td>{fundNumber}</td>
                    <td>{fundStatusType}</td>
                    <td>{shortTermRedemptionFeePercent}</td>
                    <td>{shortTermHoldingPeriod}</td>
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

    addAsset(){
        const newAsset = {
            name: this.state.inputName,
            price: this.state.inputPrice,
            quantity: this.state.inputQuantity,
            incomePaymentMonth: this.state.inputIncomePaymentMonth,
            incomePaymentDay: this.state.inputIncomePaymentDay,
            useDailyFactor: this.state.inputUseDailyFactor,
            accrualMethodType: this.state.inputAccrualMethodType,
            exchangeType: this.state.inputExchangeType,
            earningsPerShareDiluted: this.state.inputEarningsPerShareDiluted,
            fundFamilyId: this.state.inputFundFamilyId,
            fundCategoryId: this.state.inputFundCategoryId,
            fundNumber: this.state.inputFundNumber,
            fundStatusType: this.state.inputFundStatusType,
            shortTermRedemptionFeePercent: this.state.inputShortTermRedemptionFeePercent,
            shortTermHoldingPeriod: this.state.inputShortTermHoldingPeriod,
        };
        this.setState({assets:this.state.assets.concat(newAsset)})
    }

    removeAsset(){
        this.setState({asset:this.state.assets.pop()})
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
                <label>IncomePaymentMonth</label>
                <input type="number" name="inputIncomePaymentMonth" onChange={this.handleInputChange} value={this.state.inputIncomePaymentMonth}/>
                <br />
                <label>IncomePaymentDay</label>
                <input type="number" name="inputIncomePaymentDay" onChange={this.handleInputChange} value={this.state.inputIncomePaymentDay}/>
                <br />
                <label>UseDailyFactor</label>
                <select name="inputUseDailyFactor" onChange={this.handleInputChange} value={this.state.inputUseDailyFactor}>
                    <option value="true">true</option>
                    <option value="false">false</option>
                </select>
                <br />
                <label>AccrualMethodType</label>
                <input type="text" name="inputAccrualMethodType" onChange={this.handleInputChange} value={this.state.inputAccrualMethodType}/>
                <br />
                <label>ExchangeType</label>
                <input type="text" name="inputExchangeType" onChange={this.handleInputChange} value={this.state.inputExchangeType}/>
                <br />
                <label>EarningsPerShareDiluted</label>
                <input type="number" name="inputEarningsPerShareDiluted" onChange={this.handleInputChange} value={this.state.inputEarningsPerShareDiluted}/>
                <br />
                <label>FundFamilyId</label>
                <input type="number" name="inputFundFamilyId" onChange={this.handleInputChange} value={this.state.inputFundFamilyId}/>
                <br />
                <label>FundCategoryId</label>
                <input type="number" name="inputFundCategoryId" onChange={this.handleInputChange} value={this.state.inputFundCategoryId}/>
                <br />
                <label>FundNumber</label>
                <input type="number" name="inputFundNumber" onChange={this.handleInputChange} value={this.state.inputFundNumber}/>
                <br />
                <label>FundStatusType</label>
                <input type="text" name="inputFundStatusType" onChange={this.handleInputChange} value={this.state.inputFundStatusType}/>
                <br />
                <label>ShortTermRedemptionFeePercent</label>
                <input type="number" name="inputShortTermRedemptionFeePercent" onChange={this.handleInputChange} value={this.state.inputShortTermRedemptionFeePercent}/>
                <br />
                <label>ShortTermHoldingPeriod</label>
                <input type="number" name="inputShortTermHoldingPeriod" onChange={this.handleInputChange} value={this.state.inputShortTermHoldingPeriod}/>
                <br />
                <button onClick={this.addAsset}>Add Asset</button>
                <button onClick={this.removeAsset}> Remove Asset</button>
                <br/>
                <br/>
            </div>
        );
    }

}