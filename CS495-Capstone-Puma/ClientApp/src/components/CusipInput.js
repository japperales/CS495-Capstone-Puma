import React from 'react'

let state = {
    assets: [],
    inputCusip: null,
};

export class CusipInput extends React.Component{

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
            const { cusip} = asset;
            return (
                <tr key={cusip}>
                    <td>{cusip}</td>
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
            cusip: this.state.inputCusip,
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
                    <label>Cusip</label>
                    <input type="text" cusip="inputName" required onChange={this.handleInputChange} value={this.state.inputCusip}/>
                    <br />
                    <input type="submit" value="Add Asset" className="waves-effect waves-light btn-small"/>
                </form>
                <a onClick={this.removeAsset} className="waves-effect waves-light btn-small">Remove Asset</a>
                <br/>
                <br/>
            </div>
        );
    }

}