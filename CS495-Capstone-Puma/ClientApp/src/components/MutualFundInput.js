import React from 'react'

let state = {
    assets: [],
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
        if(this.state.assets.length>0) {
            let header = Object.keys(this.state.assets[0]);
            return header.map((key, index) => {
                return <th key={index}>{key.toUpperCase()}</th>
            })
        }
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

    async addAsset(event){
        event.preventDefault();
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
        await this.setState({assets: this.state.assets.concat(newAsset)});
        this.props.mutualFundCallback(this.state.assets);
    }

    async removeAsset(){
        await this.setState({asset: this.state.assets.pop()});
        this.props.mutualFundCallback(this.state.assets);
    }

    render(){
        return(
            <div>
                <h3 id='title'>Mutual Funds</h3>
                <table className='table' id='assets'>
                    <tbody>
                    <tr>{this.renderTableHeader()}</tr>
                    {this.renderTableData()}
                    </tbody>
                </table>
                <form onSubmit={this.addAsset}>
                <label>Name</label>
                <input type="text" name="inputName" required onChange={this.handleInputChange} value={this.state.inputName}/>
                <br />
                <label>Price</label>
                <input type="number" name="inputPrice" required onChange={this.handleInputChange} value={this.state.inputPrice}/>
                <br />
                <label>Quantity</label>
                <input type="number" name="inputQuantity" required onChange={this.handleInputChange} value={this.state.inputQuantity}/>
                <br />
                <label>IncomePaymentMonth</label>
                <input type="number" name="inputIncomePaymentMonth" required onChange={this.handleInputChange} value={this.state.inputIncomePaymentMonth}/>
                <br />
                <label>IncomePaymentDay</label>
                <input type="number" name="inputIncomePaymentDay" required onChange={this.handleInputChange} value={this.state.inputIncomePaymentDay}/>
                <br />
                <label>UseDailyFactor</label>
                <select name="inputUseDailyFactor" required onChange={this.handleInputChange} value={this.state.inputUseDailyFactor}>
                    <option value="true">true</option>
                    <option value="false">false</option>
                    <option value="null" selected="selected"> </option>
                </select>
                <br />
                <label>AccrualMethodType</label>
                <input type="text" name="inputAccrualMethodType" required onChange={this.handleInputChange} value={this.state.inputAccrualMethodType}/>
                <br />
                <label>ExchangeType</label>
                <input type="text" name="inputExchangeType" required onChange={this.handleInputChange} value={this.state.inputExchangeType}/>
                <br />
                <label>EarningsPerShareDiluted</label>
                <input type="number" name="inputEarningsPerShareDiluted" required onChange={this.handleInputChange} value={this.state.inputEarningsPerShareDiluted}/>
                <br />
                <label>FundFamilyId</label>
                <input type="number" name="inputFundFamilyId" required onChange={this.handleInputChange} value={this.state.inputFundFamilyId}/>
                <br />
                <label>FundCategoryId</label>
                <input type="number" name="inputFundCategoryId" required onChange={this.handleInputChange} value={this.state.inputFundCategoryId}/>
                <br />
                <label>FundNumber</label>
                <input type="number" name="inputFundNumber" required onChange={this.handleInputChange} value={this.state.inputFundNumber}/>
                <br />
                <label>FundStatusType</label>
                <input type="text" name="inputFundStatusType" required onChange={this.handleInputChange} value={this.state.inputFundStatusType}/>
                <br />
                <label>ShortTermRedemptionFeePercent</label>
                <input type="number" name="inputShortTermRedemptionFeePercent" required onChange={this.handleInputChange} value={this.state.inputShortTermRedemptionFeePercent}/>
                <br />
                <label>ShortTermHoldingPeriod</label>
                <input type="number" name="inputShortTermHoldingPeriod" required onChange={this.handleInputChange} value={this.state.inputShortTermHoldingPeriod}/>
                <br />
                <input type="submit" value={"Add Asset"} />
                </form>
                <button onClick={this.removeAsset}> Remove Asset</button>
                <br/>
                <br/>
            </div>
        );
    }

}