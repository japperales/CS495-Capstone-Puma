import React from 'react'

let state = {assets: [
        { name: 'test1', price: '45.5', quantity: 21, incomePaymentFrequencyType: "pretty frequent", incomePaymentMonth: 74654893, incomePaymentDay: 2, realEstateParcelNumber: "123 north"}
    ],
    inputName: null,
    inputPrice: null,
    inputQuantity: null,
    inputIncomePaymentFrequencyType: null,
    inputIncomePaymentMonth: null,
    inputRealEstateParcelNumber: null
};

export class Propertyinput extends React.Component{

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
            const { name, price, quantity, incomePaymentFrequencyType, incomePaymentMonth, incomePaymentDay, realEstateParcelNumber} = asset;
            return (
                <tr key={name}>
                    <td>{name}</td>
                    <td>{price}</td>
                    <td>{quantity}</td>
                    <td>{incomePaymentFrequencyType}</td>
                    <td>{incomePaymentMonth}</td>
                    <td>{incomePaymentDay}</td>
                    <td>{realEstateParcelNumber}</td>
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

    async addAsset(){
        const newAsset = {
            name: this.state.inputName,
            price: this.state.inputPrice,
            quantity: this.state.inputQuantity,
            incomePaymentFrequencyType: this.state.inputIncomePaymentFrequencyType,
            incomePaymentMonth: this.state.inputIncomePaymentMonth,
            incomePaymentDay: this.state.inputIncomePaymentDay,
            realEstateParcelNumber: this.state.inputRealEstateParcelNumber
        };
        await this.setState({assets:this.state.assets.concat(newAsset)});
        this.props.propertyCallback(this.state.assets);
    }

    async removeAsset(){
        await this.setState({asset:this.state.assets.pop()});
        this.props.propertyCallback(this.state.assets);
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
                <label>IncomePaymentFrequencyType</label>
                <input type="text" name="inputIncomePaymentFrequencyType" onChange={this.handleInputChange} value={this.state.inputIncomePaymentFrequencyType}/>
                <br />
                <label>IncomePaymentMonth</label>
                <input type="number" name="inputIncomePaymentMonth" onChange={this.handleInputChange} value={this.state.inputIncomePaymentMonth}/>
                <br />
                <label>IncomePaymentDay</label>
                <input type="number" name="inputIncomePaymentDay" onChange={this.handleInputChange} value={this.state.inputIncomePaymentDay}/>
                <br />
                <label>RealEstateParcelNumber</label>
                <input type="text" name="inputRealEstateParcelNumber" onChange={this.handleInputChange} value={this.state.inputRealEstateParcelNumber}/>
                <br />
                <button onClick={this.addAsset}>Add Asset</button>
                <button onClick={this.removeAsset}> Remove Asset</button>
                <br/>
                <br/>
            </div>
        );
    }

}