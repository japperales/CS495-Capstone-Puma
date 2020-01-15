import React from 'react'

let state = {
    assets: [],
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
        if(this.state.assets.length>0) {
            let header = Object.keys(this.state.assets[0]);
            return header.map((key, index) => {
                return <th key={index}>{key.toUpperCase()}</th>
            })
        }    
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

    async addAsset(event){
        event.preventDefault();
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
                <h3 id='title'>Properties</h3>
                <table className='table' id='assets'>
                    <tbody>
                    <tr>{this.renderTableHeader()}</tr>
                    {this.renderTableData()}
                    </tbody>
                </table>
                <form onSubmit={this.addAsset}>
                    
                <div className="center-align">
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
                        <label>IncomePaymentFrequencyType</label>
                        <input type="text" name="inputIncomePaymentFrequencyType" required onChange={this.handleInputChange} value={this.state.inputIncomePaymentFrequencyType}/>
                    </div>
                </div>
                
                <div className="center-align">
                    <div className = "input-field col s6">    
                        <label>IncomePaymentMonth</label>
                        <input type="number" name="inputIncomePaymentMonth" required onChange={this.handleInputChange} value={this.state.inputIncomePaymentMonth}/>
                    </div>
                </div>
                
                <div className="center-align">
                    <div className = "input-field col s6">    
                        <label>IncomePaymentDay</label>
                        <input type="number" name="inputIncomePaymentDay" required onChange={this.handleInputChange} value={this.state.inputIncomePaymentDay}/>
                    </div>
                </div>
                
                <div className="center-align">
                    <div className = "input-field col s6">    
                        <label>RealEstateParcelNumber</label>
                        <input type="text" name="inputRealEstateParcelNumber" required onChange={this.handleInputChange} value={this.state.inputRealEstateParcelNumber}/>
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