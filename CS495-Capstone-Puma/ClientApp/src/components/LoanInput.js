import React from 'react'

let state = {assets: [
        { name: 'test1', price: '45.5', quantity: 21, dateOfIssue: "04/30/1997", dateOfMaturity: "01/01/2030", dateOfFirstPayment: "11/25/2005",

            incomePaymentMonth: 12345, incomePaymentDay: 54321, accrualMethodType: "annually",

            paymentFrequencyType: "monthly", incomePaymentFrequencyType: "Monthly", compoundingFrequencyType: "monthly", amortizationFrequencyType: "frequent", periodicPaymentAmount: 1000.000}
    ],
    inputName: null,
    inputPrice: null,
    inputQuantity: null,
    inputDateOfIssue: null,
    inputDateOfMaturity: null,
    inputDateOfFirstPayment: null,
    inputIncomePaymentMonth: null,
    inputIncomePaymentDay: null,
    inputAccrualMethodType: null,
    inputPaymentFrequencyType: null,
    inputIncomePaymentFrequencyType: null,
    inputCompoundingFrequencyType: null,
    inputAmortizationFrequencyType: null,
    inputPeriodicPaymentAmount: null
};

export class LoanInput extends React.Component{

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
            const { name, price, quantity, dateOfIssue,

                dateOfMaturity, dateOfFirstPayment, incomePaymentMonth, incomePaymentDay,

                accrualMethodType, paymentFrequencyType, incomePaymentFrequencyType, compoundingFrequencyType, amortizationFrequencyType, periodicPaymentAmount} = asset;
            return (
                <tr key={name}>
                    <td>{name}</td>
                    <td>{price}</td>
                    <td>{quantity}</td>
                    <td>{dateOfIssue}</td>
                    <td>{dateOfMaturity}</td>
                    <td>{dateOfFirstPayment}</td>
                    <td>{incomePaymentMonth}</td>
                    <td>{incomePaymentDay}</td>
                    <td>{accrualMethodType}</td>
                    <td>{paymentFrequencyType}</td>
                    <td>{incomePaymentFrequencyType}</td>
                    <td>{compoundingFrequencyType}</td>
                    <td>{amortizationFrequencyType}</td>
                    <td>{periodicPaymentAmount}</td>
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
            dateOfIssue: this.state.inputDateOfIssue,//add asset part works fine
            dateOfMaturity: this.state.inputDateOfMaturity,
            dateOfFirstPayment: this.state.inputDateOfFirstPayment,
            incomePaymentMonth: this.state.inputIncomePaymentMonth,
            incomePaymentDay: this.state.inputIncomePaymentDay,
            accrualMethodType: this.state.inputAccrualMethodType,
            paymentFrequencyType: this.state.inputPaymentFrequencyType,
            incomePaymentFrequencyType: this.state.inputIncomePaymentFrequencyType,
            compoundingFrequencyType: this.state.inputCompoundingFrequencyType,
            amortizationFrequencyType: this.state.inputAmortizationFrequencyType,
            periodicPaymentAmount: this.state.inputPeriodicPaymentAmount
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
                <label>DateOfIssue</label>
                <input type="date" name="inputDateOfIssue" onChange={this.handleInputChange} value={this.state.inputDateOfIssue}/>
                <br />
                <label> DateOfMaturity</label>
                <input type="date" name="inputDateOfMaturity" onChange={this.handleInputChange} value={this.state.inputDateOfMaturity}/>
                <br />
                <label>DateOfFirstPayment</label>
                <input type="date" name="inputDateOfFirstPayment" onChange={this.handleInputChange} value={this.state.inputDateOfFirstPayment}/>
                <br />
                <label>IncomePaymentMonth</label>
                <input type="number" name="inputIncomePaymentMonth" onChange={this.handleInputChange} value={this.state.inputIncomePaymentMonth}/>
                <br />
                <label>IncomePaymentDay</label>
                <input type="number" name="inputIncomePaymentDay" onChange={this.handleInputChange} value={this.state.inputIncomePaymentDay}/>
                <br />
                <label>AccrualMethodType</label>
                <input type="text" name="inputAccrualMethodType" onChange={this.handleInputChange} value={this.state.inputAccrualMethodType}/>
                <br />
                <label>PaymentFrequencyType</label>
                <input type="text" name="inputPaymentFrequencyType" onChange={this.handleInputChange} value={this.state.inputPaymentFrequencyType}/>
                <br />
                <label>IncomePaymentFrequencyType</label>
                <input type="text" name="inputIncomePaymentFrequencyType" onChange={this.handleInputChange} value={this.state.inputIncomePaymentFrequencyType}/>
                <br />
                <label>CompoundingFrequencyType</label>
                <input type="text" name="inputCompoundingFrequencyType" onChange={this.handleInputChange} value={this.state.inputCompoundingFrequencyType}/>
                <br />
                <label>AmortizationFrequencyType</label>
                <input type="text" name="inputAmortizationFrequencyType" onChange={this.handleInputChange} value={this.state.inputAmortizationFrequencyType}/>
                <br />
                <label>PeriodicPaymentAmount</label>
                <input type="number" name="inputPeriodicPaymentAmount" onChange={this.handleInputChange} value={this.state.inputPeriodicPaymentAmount}/>
                <br />
                <button onClick={this.addAsset}>Add Asset</button>
                <button onClick={this.removeAsset}> Remove Asset</button>
                <br/>
                <br/>
            </div>
        );
    }

}