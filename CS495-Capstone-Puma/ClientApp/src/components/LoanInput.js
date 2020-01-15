import React from 'react'
import M from "materialize-css";

let state = {
    assets: [],
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

    async addAsset(event){
        event.preventDefault();
        const newAsset = {
            name: this.state.inputName,
            price: this.state.inputPrice,
            quantity: this.state.inputQuantity,
            dateOfIssue: this.state.inputDateOfIssue,
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
        await this.setState({assets:this.state.assets.concat(newAsset)});
        this.props.loanCallback(this.state.assets);
    }

    async removeAsset(){
        await this.setState({asset:this.state.assets.pop()});
        this.props.loanCallback(this.state.assets);
    }

    render(){
        return(
            <div>
                <h3 id='title'>Loans</h3>
                <table className='table' id='assets'>
                    <tbody>
                    <tr>{this.renderTableHeader()}</tr>
                    {this.renderTableData()}
                    </tbody>
                </table>
                <form onSubmit={this.addAsset}>
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
            </div>
        );
    }

}