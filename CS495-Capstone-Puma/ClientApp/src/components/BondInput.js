import React from 'react'
import M from 'materialize-css';
import MaterialTable from "material-table";
//Stored state for subsequent render memory
let state = {
    data: [],
    columns: [
        { title: 'Name', field: 'name', initialEditValue: 'name' },
        { title: 'Price', field: 'price', initialEditValue: '0', type: 'numeric' },
        { title: 'Quantity', field: 'quantity', initialEditValue: '1', type: 'numeric' },
        { title: 'Date of Issue', field: 'dateOfIssue', type: 'date' },
        { title: 'Date of Maturity', field: 'dateOfMaturity', type: 'date' },
        { title: 'Income (Month)', field: 'incomePaymentMonth', initialEditValue: '0', type: 'numeric' },
        { title: 'Income (Day)', field: 'incomePaymentDay', initialEditValue: '0', type: 'numeric' },
        { title: 'Accrual Method', field: 'accrualMethod', initialEditValue: 'Type' },
        { title: 'Call Date', field: 'callDate', type: 'date' },
        { title: 'Call Price', field: 'callPrice', initialEditValue: '0', type: 'numeric' },
        {
            title: 'Date of First Payment', field: 'dateOfIssue', type: 'date'
            //lookup: { 34: 'İstanbul', 63: 'Şanlıurfa' },
        },
    ]
};

export class BondInput extends React.Component{
    
    componentDidMount(){
        console.log("component did mount");
        M.AutoInit();
    }
    
    constructor(props) {
        super(props);
        this.state = state;
    }
    
    //saving state for next render(s)
    componentWillUnmount() {
        state = this.state;
    }
    
    render(){
        return(
            <div>
                <h3 id='title'>Bonds</h3>
                <MaterialTable
                    title="Bonds Table"
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
                            <div className="input-field col s6">
                                <label>Name</label>
                                <input type="text" name="inputName" required onChange={this.handleInputChange} value={this.state.inputName}/>
                            </div>
                        </div>
    
                        <div className="center-align">
                            <div className="input-field col s6">
                                <label>Price</label>
                                <input type="number" name="inputPrice" required onChange={this.handleInputChange} value={this.state.inputPrice}/>
                            </div>
                        </div>
    
                        <div className="center-align">
                            <div className="input-field col s6">
                                <label>Quantity</label>
                                <input type="number" name="inputQuantity" required onChange={this.handleInputChange} value={this.state.inputQuantity}/>
                            </div>
                        </div>
    
                        <div className="center-align">
                            <div className="input-field col s6">
                                <label>Date Of Issue</label>
                                <input type="text" className="datepicker" name="inputDateOfIssue" required onChange={this.handleInputChange} value={this.state.inputDateOfIssue}/>
                            </div>
                        </div>
    
                        <div className="center-align">
                            <div className="input-field col s6">
                                <label>Date Of Maturity</label>
                                <input type="text" className="datepicker" name="inputDateOfMaturity" required onChange={this.handleInputChange} value={this.state.inputDateOfMaturity}/>
                            </div>
                        </div>
    
                        <div className="center-align">
                            <div className="input-field col s6">
                                <label>Income Payment Month</label>
                                <input type="number" name="inputIncomePaymentMonth" required onChange={this.handleInputChange} value={this.state.inputIncomePaymentMonth}/>
                            </div>
                        </div>
    
                        <div className="center-align">
                            <div className="input-field col s6">
                                <label>Income Payment Day</label>
                                <input type="number" name="inputIncomePaymentDay" required onChange={this.handleInputChange} value={this.state.inputIncomePaymentDay}/>
                            </div>
                        </div>
    
                        <div className="center-align">
                            <div className="input-field col s6">
                                <label>Accrual Method Type</label>
                                <input type="text" name="inputAccrualMethodType" required onChange={this.handleInputChange} value={this.state.inputAccrualMethodType}/>
                            </div>
                        </div>
    
                        <div className="center-align">
                            <div className="input-field col s6">
                                <label>Call Date</label>
                                <input type="text" className="datepicker" name="inputCallDate" required onChange={this.handleInputChange} value={this.state.inputCallDate}/>
                            </div>
                        </div>
    
                        <div className="center-align">
                            <div className="input-field col s6">
                                <label>Call Price</label>
                                <input type="text" className="datepicker" name="inputCallPrice" required onChange={this.handleInputChange} value={this.state.inputCallPrice}/>
                            </div>
                        </div>
    
                        <div className="center-align">
                            <div className="input-field col s6">
                                <label>Date Of First Payment</label>
                                <input type="text" className="datepicker" name="inputDateOfFirstPayment" required onChange={this.handleInputChange} value={this.state.inputDateOfFirstPayment}/>
                            </div>
                        </div>
    
                        <input type="submit" value="Add Asset" className="waves-effect waves-light btn"/>
                    </form>
                    <a onClick={this.removeAsset} className="waves-effect waves-light btn">Remove Asset</a>
                    <br/>
                    <br/>
                    
                   */
}