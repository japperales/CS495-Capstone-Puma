import React from 'react'
import M from 'materialize-css'
import MaterialTable from "material-table";

let state = {
    data: [],
    columns: [
        { title: 'Name', field: 'name', initialEditValue: 'name' },
        { title: 'Price', field: 'price', initialEditValue: '0', type: 'numeric' },
        { title: 'Quantity', field: 'quantity', initialEditValue: '1', type: 'numeric' },
        { title: 'Income Payment Frequency', field: 'incomePaymentFrequencyType', initialEditValue: '0', type: 'numeric' },
        { title: 'Income (Day)', field: 'incomePaymentDay', initialEditValue: '0', type: 'numeric' },
        { title: 'Income (Month)', field: 'incomePaymentMonth', initialEditValue: '0', type: 'numeric' },
        {
            title: 'Uses Daily Factor', field: 'usesDailyFactor', initialEditValue: 'False', 
            lookup: { 34: 'True', 63: 'False' }
        },
        { title: 'Accrual Method', field: 'accrualMethod', initialEditValue: 'Type' },
        { title: 'Exchange Type', field: 'exchangeType', initialEditValue: 'Type' },
        { title: 'Earning Per Share', field: 'earningsPerShareDiluted', type: 'numeric' },
        { title: 'Fund Family', field: 'fundFamilyId' },
        { title: 'Fund Category', field: 'fundFamilyId' },
        { title: 'Fund Number', field: 'fundNumber', initialEditValue: '0', type: 'numeric'},
        { title: 'Fund Status', field: 'fundStatusType', initialEditValue: 'Type' },
        { title: 'Short Term Redemption Fee %', field: 'shortTermRedemptionFeePercent', initialEditValue: 'Type', type: 'numeric' },
        { title: 'Short Term Holding Period', field: 'shortTermHoldingPeriod', initialEditValue: 'Type', type: 'numeric' },
        { title: 'Call Price', field: 'callPrice', initialEditValue: '0', type: 'numeric' },
        {
            title: 'Date of First Payment', field: 'dateOfIssue', type: 'date'
            //lookup: { 34: 'İstanbul', 63: 'Şanlıurfa' },
        },
    ]
};

export class MutualFundInput extends React.Component{
    componentDidMount(){
        console.log("component did mount")
        M.AutoInit();
    }

    constructor(props) {
        super(props);
        this.state = state;
    }

    componentWillUnmount() {
        state = this.state;
    }
    
    render(){
        return(
            <div>
                <h3 id='title'>Mutual Funds</h3>
                <MaterialTable
                    title="Mutual Fund Table"
                    columns={this.state.columns}
                    data={this.state.data}
                    editable={{
                        onRowAdd: newData =>
                            new Promise((resolve, reject) => {
                                setTimeout(() => {
                                    {
                                        let data =[...this.state.data];
                                        data.push(newData);
                                        console.log("new data array is now: " + JSON.stringify(data));
                                        this.setState({ data }, () => resolve());
                                        console.log("state is now: " + JSON.stringify(this.state.data))
                                    }
                                    resolve()
                                }, 1000)
                            }),
                        onRowUpdate: (newData, oldData) =>
                            new Promise((resolve, reject) => {
                                setTimeout(() => {
                                    {
                                        let data =[...this.state.data];
                                        const index = data.indexOf(oldData);
                                        data[index] = newData;
                                        this.setState({ data }, () => resolve());
                                    }
                                    resolve()
                                }, 1000)
                            }),
                        onRowDelete: oldData =>
                            new Promise((resolve, reject) => {
                                setTimeout(() => {
                                    {
                                        let data =[...this.state.data];
                                        const index = data.indexOf(oldData);
                                        data.splice(index, 1);
                                        this.setState({ data }, () => resolve());
                                    }
                                    resolve()
                                }, 1000)
                            }),
                    }}

                />
                
            </div>
        );
    }

    /*<form onSubmit={this.addAsset}>
                    
                <div className="center-align">
                    <div className = "input-field col s6">    
                        <label>Name</label>
                        <input type="text" name="inputName" required onChange={this.handleInputChange} value={this.state.inputName}/>
                    </div>
                </div>
                
                <div className = "center-align">
                    <div className = "input-field col s6">
                        <label>Price</label>
                        <input type="number" name="inputPrice" required onChange={this.handleInputChange} value={this.state.inputPrice}/>
                    </div>
                </div>
                
                <div className = "center-align">
                    <div className = "input-field col s6">    
                        <label>Quantity</label>
                        <input type="number" name="inputQuantity" required onChange={this.handleInputChange} value={this.state.inputQuantity}/>
                    </div>
                </div>
                   
                <div className = "center-align">
                    <div className = "input-field col s6">    
                        <label>IncomePaymentMonth</label>
                        <input type="number" name="inputIncomePaymentMonth" required onChange={this.handleInputChange} value={this.state.inputIncomePaymentMonth}/>
                    </div>
                </div>
                    
                <div className = "center-align">
                    <div className = "input-field col s6">    
                        <label>IncomePaymentDay</label>
                        <input type="number" name="inputIncomePaymentDay" required onChange={this.handleInputChange} value={this.state.inputIncomePaymentDay}/>
                    </div>
                </div>
                    
                <div className="center-align">
                    <div className = "input-field col s6">
                        <select name="inputUseDailyFactor" required onChange={this.handleInputChange} value={this.state.inputUseDailyFactor}>
                            <option value="true">true</option>
                            <option value="false">false</option>
                            <option value="null" selected="selected"> </option>
                        </select>
                        <label>UseDailyFactor</label>
                    </div>
                </div>
                    
                <div className = "center-align">
                    <div className = "input-field col s6">    
                        <label>AccrualMethodType</label>
                        <input type="text" name="inputAccrualMethodType" required onChange={this.handleInputChange} value={this.state.inputAccrualMethodType}/>
                    </div>
                </div>
                    
                <div className = "center-align">
                    <div className = "input-field col s6">    
                        <label>ExchangeType</label>
                        <input type="text" name="inputExchangeType" required onChange={this.handleInputChange} value={this.state.inputExchangeType}/>
                    </div>
                </div>
                    
                <div className = "center-align">
                    <div className = "input-field col s6">    
                        <label>EarningsPerShareDiluted</label>
                        <input type="number" name="inputEarningsPerShareDiluted" required onChange={this.handleInputChange} value={this.state.inputEarningsPerShareDiluted}/>
                    </div>
                </div>
                
                <div className = "center-align">
                    <div className = "input-field col s6">    
                        <label>FundFamilyId</label>
                        <input type="number" name="inputFundFamilyId" required onChange={this.handleInputChange} value={this.state.inputFundFamilyId}/>
                    </div>
                </div>
                
                <div className = "center-align">
                    <div className = "input-field col s6">    
                        <label>FundCategoryId</label>
                        <input type="number" name="inputFundCategoryId" required onChange={this.handleInputChange} value={this.state.inputFundCategoryId}/>
                    </div>
                </div>
                
                <div className = "center-align">
                    <div className = "input-field col s6">    
                        <label>FundNumber</label>
                        <input type="number" name="inputFundNumber" required onChange={this.handleInputChange} value={this.state.inputFundNumber}/>
                    </div>
                </div>
                
                <div className = "center-align">
                    <div className = "input-field col s6">    
                        <label>FundStatusType</label>
                        <input type="text" name="inputFundStatusType" required onChange={this.handleInputChange} value={this.state.inputFundStatusType}/>
                    </div>
                </div>
                
                <div className = "center-align">
                    <div className = "input-field col s6">    
                        <label>ShortTermRedemptionFeePercent</label>
                        <input type="number" name="inputShortTermRedemptionFeePercent" required onChange={this.handleInputChange} value={this.state.inputShortTermRedemptionFeePercent}/>
                    </div>
                </div>
                    
                <div className = "center-align">
                    <div className = "input-field col s6">    
                        <label>ShortTermHoldingPeriod</label>
                        <input type="number" name="inputShortTermHoldingPeriod" required onChange={this.handleInputChange} value={this.state.inputShortTermHoldingPeriod}/>
                    </div>
                </div>
                    
                    <input type="submit" value="Add Asset" className="waves-effect waves-light btn-small"/>
                </form>
                <a onClick={this.removeAsset} className="waves-effect waves-light btn-small">Remove Asset</a>
                <br/>
                <br/>
                
     */
}