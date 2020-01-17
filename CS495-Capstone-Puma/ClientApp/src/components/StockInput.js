import React from 'react'
import M from 'materialize-css'
import MaterialTable from "material-table";

let state = {
    data: [],
    columns: [
        { title: 'Name', field: 'name', initialEditValue: 'name' },
        { title: 'Price', field: 'price', initialEditValue: '0', type: 'numeric' },
        { title: 'Quantity', field: 'quantity', initialEditValue: '1', type: 'numeric' },
        { title: 'Exchange Type', field: 'exchangeType', initialEditValue: 'Type' },
        { title: 'Earning Per Share', field: 'earningsPerShareDiluted', initialEditValue: '0', type: 'numeric' },
        { title: 'Earning Per Share Effective Date', field: 'earningsPerShareEffectiveDate', type: 'date' },
        { title: 'Payment Frequency Type', field: 'paymentFrequencyType', initialEditValue: 'Type' },
        { title: 'Shares Outstanding', field: 'sharesOutstanding', initialEditValue: '0', type: 'numeric' },
        {
            title: 'Is Included In 13F', field: 'isIncludedIn13F', initialEditValue: 'False',
            lookup: { 34: 'True', 63: 'False' }
        },
        {
            title: 'Is Restricted By 144A', field: 'isRestrictedByRule144A', initialEditValue: 'False',
            lookup: { 34: 'True', 63: 'False' }
        },
        { title: 'Calculated Market Cap Type', field: 'calculatedMarketCapType', initialEditValue: 'Type'  }
    ]
};

export class StockInput extends React.Component{
    
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
                <h3 id='title'>Stocks</h3>
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
/*<div className="center-align">
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
                
                <a onClick={this.removeAsset} className="waves-effect waves-light btn-small">Remove Asset</a>
                <br/>
                <br/>
                
 */
}