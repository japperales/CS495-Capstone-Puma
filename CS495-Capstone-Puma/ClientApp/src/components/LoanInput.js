import React from 'react'
import M from "materialize-css";
import MaterialTable from "material-table";

let state = {
    data: [],
    columns: [
        { title: 'Name', field: 'name', initialEditValue: 'name' },
        { title: 'Price', field: 'price', initialEditValue: '0', type: 'numeric' },
        { title: 'Quantity', field: 'quantity', initialEditValue: '1', type: 'numeric' },
        { title: 'Date of Issue', field: 'dateOfIssue', type: 'date' },
        { title: 'Date of Maturity', field: 'dateOfMaturity', type: 'date' },
        { title: 'Date of First Payment', field: 'dateOfFirstPayment', type: 'date' },
        { title: 'Income (Month)', field: 'incomePaymentMonth', initialEditValue: '0', type: 'numeric' },
        { title: 'Income (Day)', field: 'incomePaymentDay', initialEditValue: '0', type: 'numeric' },
        { title: 'Accrual Method', field: 'accrualMethod', initialEditValue: 'Type' },
        { title: 'Payment Frequency', field: 'paymentFrequencyType', initialEditValue: 'Type' },
        { title: 'Compounding Frequency Type', field: 'compoundingFrequencyType', initialEditValue: 'Type' },
        { title: 'Amortization Frequency Type', field: 'amortizationFrequencyType', initialEditValue: 'Type' },
        { title: 'Call Date', field: 'callDate', type: 'date' }
    ]
};

export class LoanInput extends React.Component{
    componentDidMount(){
        console.log("component did mount");
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
                <h3 id='title'>Loans</h3>
                <MaterialTable
                    title="Loans Table"
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
                <label>DateOfIssue</label>
                <input type="text" className="datepicker" name="inputDateOfIssue" required onChange={this.handleInputChange} value={this.state.inputDateOfIssue}/>
                        </div> 
                    </div>

                    <div className="center-align">
                        <div className="input-field col s6">
                <label>DateOfMaturity</label>
                <input type="text" className="datepicker" name="inputDateOfMaturity" required onChange={this.handleInputChange} value={this.state.inputDateOfMaturity}/>
                        </div>
                    </div>

                    <div className="center-align">
                        <div className="input-field col s6">
                <label>DateOfFirstPayment</label>
                <input type="text" className="datepicker" name="inputDateOfFirstPayment" required onChange={this.handleInputChange} value={this.state.inputDateOfFirstPayment}/>
                        </div>
                    </div>

                    <div className="center-align">
                        <div className="input-field col s6">
                <label>IncomePaymentMonth</label>
                <input type="number" name="inputIncomePaymentMonth" required onChange={this.handleInputChange} value={this.state.inputIncomePaymentMonth}/>
                        </div>
                    </div>

                    <div className="center-align">
                        <div className="input-field col s6">
                <label>IncomePaymentDay</label>
                <input type="number" name="inputIncomePaymentDay" required onChange={this.handleInputChange} value={this.state.inputIncomePaymentDay}/>
                        </div>
                    </div>

                    <div className="center-align">
                        <div className="input-field col s6">
                <label>AccrualMethodType</label>
                <input type="text" name="inputAccrualMethodType" required onChange={this.handleInputChange} value={this.state.inputAccrualMethodType}/>
                        </div>
                    </div>

                    <div className="center-align">
                        <div className="input-field col s6">
                <label>PaymentFrequencyType</label>
                <input type="text" name="inputPaymentFrequencyType" required onChange={this.handleInputChange} value={this.state.inputPaymentFrequencyType}/>
                        </div>
                    </div>

                    <div className="center-align">
                        <div className="input-field col s6">
                <label>IncomePaymentFrequencyType</label>
                <input type="text" name="inputIncomePaymentFrequencyType" required onChange={this.handleInputChange} value={this.state.inputIncomePaymentFrequencyType}/>
                        </div>
                    </div>

                    <div className="center-align">
                        <div className="input-field col s6">
                <label>CompoundingFrequencyType</label>
                <input type="text" name="inputCompoundingFrequencyType" required onChange={this.handleInputChange} value={this.state.inputCompoundingFrequencyType}/>
                        </div>
                    </div>

                    <div className="center-align">
                        <div className="input-field col s6">
                <label>AmortizationFrequencyType</label>
                <input type="text" name="inputAmortizationFrequencyType" required onChange={this.handleInputChange} value={this.state.inputAmortizationFrequencyType}/>
                        </div>
                    </div>

                    <div className="center-align">
                        <div className="input-field col s6">
                <label>PeriodicPaymentAmount</label>
                <input type="number" name="inputPeriodicPaymentAmount" required onChange={this.handleInputChange} value={this.state.inputPeriodicPaymentAmount}/>
                        </div>
                    </div>
                <input type="submit" value="Add Asset" className="waves-effect waves-light btn-small"/>
                </form>
                <a onClick={this.removeAsset} className="waves-effect waves-light btn-small">Remove Asset</a>
                <br/>
                <br/>
                
 */
}