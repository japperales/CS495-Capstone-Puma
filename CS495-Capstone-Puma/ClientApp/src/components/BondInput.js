import React from 'react'
import M from 'materialize-css';
//Stored state for subsequent render memory
let state = {
    assets: [],
    inputName: null,
    inputPrice: null,
    inputQuantity: null,
    inputDateOfIssue: null,
    inputDateOfMaturity: null,
    inputIncomePaymentMonth: null,
    inputIncomePaymentDay: null,
    inputAccrualMethodType: null,
    inputCallDate: null,
    inputCallPrice: null,
    inputDateOfFirstPayment: null
};

export class BondInput extends React.Component{
    
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
    //saving state for next render(s)
    componentWillUnmount() {
        state = this.state;
    }
    //rendering Table Headers dynamically based on fields of asset objects
    renderTableHeader() {
        if(this.state.assets.length>0) {
            let header = Object.keys(this.state.assets[0]);
            return header.map((key, index) => {
                return <th key={index}>{key.toUpperCase()}</th>
            })
        }
    }

    //rendering data of each asset iteratively
    renderTableData() {
        return this.state.assets.map((asset, index) => {
            const { name, price, quantity, dateOfIssue,
                
                dateOfMaturity, incomePaymentMonth, incomePaymentDay,
                
                accrualMethodType, callDate, callPrice, dateOfFirstPayment} = asset;
            return (
                <tr key={name}>
                    <td>{name}</td>
                    <td>{price}</td>
                    <td>{quantity}</td>
                    <td>{dateOfIssue}</td>
                    <td>{dateOfMaturity}</td>
                    <td>{incomePaymentMonth}</td>
                    <td>{incomePaymentDay}</td>
                    <td>{accrualMethodType}</td>
                    <td>{callDate}</td>
                    <td>{callPrice}</td>
                    <td>{dateOfFirstPayment}</td>
                </tr>
            )
        })
    }

    //assigning input of any changes in input fields to their corresponding input variables in state
    handleInputChange(event){

        const target = event.target;
        const value = event.target.value;
        const name = target.name;

        this.setState({
            [name]: value
        });

    }

    //Adding asset object to list of assets for this subcomponent from input variables,
    //then updating parent component data accordingly
    async addAsset(event){
        event.preventDefault();
        const newAsset = {
            name: this.state.inputName,
            price: this.state.inputPrice,
            quantity: this.state.inputQuantity,
            dateOfIssue: this.state.inputDateOfIssue,
            dateOfMaturity: this.state.inputDateOfMaturity,
            incomePaymentMonth: this.state.inputIncomePaymentMonth,
            incomePaymentDay: this.state.inputIncomePaymentDay,
            accrualMethodType: this.state.inputAccrualMethodType,
            callDate: this.state.inputCallDate,
            callPrice: this.state.inputCallPrice,
            dateOfFirstPayment: this.state.inputDateOfFirstPayment
        };
        await this.setState({assets: this.state.assets.concat(newAsset)});
        this.props.bondCallback(this.state.assets);
    }
    //pops last asset out of list, if there are any 
    async removeAsset(){
        await this.setState({asset: this.state.assets.pop()});
        this.props.bondCallback(this.state.assets);
    }

    render(){
        return(
            <div>
                <h3 id='title'>Bonds</h3>
                <table className='table' id='assets'>
                    <tbody>
                    <tr>{this.renderTableHeader()}</tr>
                    {this.renderTableData()}
                    </tbody>
                </table>
                <form onSubmit={this.addAsset}>
                    <div className="row">
                        <div className="input-field col s6">
                            <label>Name</label>
                            <input type="text" name="inputName" required onChange={this.handleInputChange} value={this.state.inputName}/>
                        </div>
                    </div>

                    <div className="row">
                        <div className="input-field col s6">
                            <label>Price</label>
                            <input type="number" name="inputPrice" required onChange={this.handleInputChange} value={this.state.inputPrice}/>
                        </div>
                    </div>

                    <div className="row">
                        <div className="input-field col s6">
                            <label>Quantity</label>
                            <input type="number" name="inputQuantity" required onChange={this.handleInputChange} value={this.state.inputQuantity}/>
                        </div>
                    </div>

                    <div className="row">
                        <div className="input-field col s6">
                            <label>Date Of Issue</label>
                            <input type="text" className="datepicker" name="inputDateOfIssue" required onChange={this.handleInputChange} value={this.state.inputDateOfIssue}/>
                        </div>
                    </div>

                    <div className="row">
                        <div className="input-field col s6">
                            <label>Date Of Maturity</label>
                            <input type="text" className="datepicker" name="inputDateOfMaturity" required onChange={this.handleInputChange} value={this.state.inputDateOfMaturity}/>
                        </div>
                    </div>

                    <div className="row">
                        <div className="input-field col s6">
                            <label>Income Payment Month</label>
                            <input type="number" name="inputIncomePaymentMonth" required onChange={this.handleInputChange} value={this.state.inputIncomePaymentMonth}/>
                        </div>
                    </div>

                    <div className="row">
                        <div className="input-field col s6">
                            <label>Income Payment Day</label>
                            <input type="number" name="inputIncomePaymentDay" required onChange={this.handleInputChange} value={this.state.inputIncomePaymentDay}/>
                        </div>
                    </div>

                    <div className="row">
                        <div className="input-field col s6">
                            <label>Accrual Method Type</label>
                            <input type="text" name="inputAccrualMethodType" required onChange={this.handleInputChange} value={this.state.inputAccrualMethodType}/>
                        </div>
                    </div>

                    <div className="row">
                        <div className="input-field col s6">
                            <label>Call Date</label>
                            <input type="date" className="datepicker" name="inputCallDate" required onChange={this.handleInputChange} value={this.state.inputCallDate}/>
                        </div>
                    </div>

                    <div className="row">
                        <div className="input-field col s6">
                            <label>Call Price</label>
                            <input type="text" className="datepicker" name="inputCallPrice" required onChange={this.handleInputChange} value={this.state.inputCallPrice}/>
                        </div>
                    </div>

                    <div className="row">
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
            </div>
        );
    }

}