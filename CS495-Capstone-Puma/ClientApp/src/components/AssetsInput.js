import React from 'react'

let state = {assets: [
        { name: 'test1', price: '45.5', quantity: 21 },
        { name: 'test2', price: '23.4', quantity: 45 },
        { name: 'test3', price: '13.8', quantity: 64 },
        { name: 'test4', price: '12', quantity: 32 }
    ],
    inputName: "",
    inputPrice: null,
    inputQuantity: null
};

export class AssetsInput extends React.Component{
    state ={};
    constructor(props) {
        super(props);
        this.state = state;
        this.addAsset = this.addAsset.bind(this);
        this.removeAsset = this.addAsset.bind(this);
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
            const { name, price, quantity } = asset;
            return (
                <tr key={name}>
                    <td>{name}</td>
                    <td>{price}</td>
                    <td>{quantity}</td>
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
            quantity: this.state.inputQuantity
        };
        this.setState({assets:this.state.assets.concat(newAsset),
            inputName: "",
            inputPrice: null,
            inputQuantity: null
        })
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
                <label>Price</label>
                <input type="number" name="inputPrice" onChange={this.handleInputChange} value={this.state.inputPrice}/>
                <label>Quantity</label>
                <input type="number" name="inputQuantity" onChange={this.handleInputChange} value={this.state.inputQuantity}/>
                <button onClick={this.addAsset}>Add Asset</button>
                <br/>
                <br/>
            </div>
        );
    }

}