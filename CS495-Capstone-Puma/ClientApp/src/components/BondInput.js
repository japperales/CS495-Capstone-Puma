import React from 'react'
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
                <label>Name</label>
                <input type="text" name="inputName" required onChange={this.handleInputChange} value={this.state.inputName}/>
                <br />
                <label>Price</label>
                <input type="number" name="inputPrice" required onChange={this.handleInputChange} value={this.state.inputPrice}/>
                <br />
                <label>Quantity</label>
                <input type="number" name="inputQuantity" required onChange={this.handleInputChange} value={this.state.inputQuantity}/>
                <br />
                <label>DateOfIssue</label>
                <input type="date" name="inputDateOfIssue" required onChange={this.handleInputChange} value={this.state.inputDateOfIssue}/>
                <br />
                <label>DateOfMaturity</label>
                <input type="date" name="inputDateOfMaturity" required onChange={this.handleInputChange} value={this.state.inputDateOfMaturity}/>
                <br />
                <label>IncomePaymentMonth</label>
                <input type="number" name="inputIncomePaymentMonth" required onChange={this.handleInputChange} value={this.state.inputIncomePaymentMonth}/>
                <br />
                <label>IncomePaymentDay</label>
                <input type="number" name="inputIncomePaymentDay" required onChange={this.handleInputChange} value={this.state.inputIncomePaymentDay}/>
                <br />
                <label>AccrualMethodType</label>
                <input type="text" name="inputAccrualMethodType" required onChange={this.handleInputChange} value={this.state.inputAccrualMethodType}/>
                <br />
                <label>CallDate</label>
                <input type="date" name="inputCallDate" required onChange={this.handleInputChange} value={this.state.inputCallDate}/>
                <br />
                <label>CallPrice</label>
                <input type="date" name="inputCallPrice" required onChange={this.handleInputChange} value={this.state.inputCallPrice}/>
                <br />
                <label>DateOfFirstPayment</label>
                <input type="date" name="inputDateOfFirstPayment" required onChange={this.handleInputChange} value={this.state.inputDateOfFirstPayment}/>
                <br />
                <input type="submit" value="Add Asset" />
                </form>    
                <button onClick={this.removeAsset}> Remove Asset</button>
                <br/>
                <br/>
            </div>
        );
    }

}