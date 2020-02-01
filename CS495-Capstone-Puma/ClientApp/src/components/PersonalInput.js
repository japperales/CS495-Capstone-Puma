import React from 'react';
import  './css/PersonalInput.css'
import M from 'materialize-css'

let state ={
    inputFirstName: null,
    inputMiddleName: null,
    inputLastName: null,
    inputHonorific: null,
    inputEmailAddress:null
};

export class PersonalInput extends React.Component{
    componentDidMount(){
        console.log("component did mount");
        M.AutoInit();
    }

    constructor(props){
        super(props);
        this.state = state;
        this.handleInputChange = this.handleInputChange.bind(this);
    }

    componentWillUnmount() {
        state = this.state;
    }

    async handleInputChange(event){

        const target = event.target;
        const value = event.target.value;
        const name = target.name;

        await this.setState({
            [name]: value
        });
        this.props.personalCallback(this.state.inputFirstName, this.state.inputMiddleName, this.state.inputLastName, this.state.inputHonorific, this.state.inputEmailAddress);
    }

    render(){
        return(
            <div className="container">
                <div className="row">
                    <div className="col s6 offset-s3">
                    <h3>Input</h3>
                    <br />
                    <div>
                        <div className = "input-field">
                            <label>Asset Code</label>
                            <input type="text" name="inputFirstName" onChange={this.handleInputChange} value={this.state.inputFirstName}/>
                        </div>
                    </div>

                    <div>
                        <div className = "input-field">
                            <label>Symbol</label>
                            <input type="text" name="inputMiddleName" onChange={this.handleInputChange} value={this.state.inputMiddleName}/>
                        </div>
                    </div>

                    <div>
                        <div className = "input-field">
                            <label>Issue</label>
                            <input type="text" name="inputLastName" onChange={this.handleInputChange} value={this.state.inputLastName}/>
                        </div>
                    </div>

                    <div>
                        <div className = "input-field">
                            <label>Issuer</label>
                            <input type="text" name="inputHonorific" onChange={this.handleInputChange}  value={this.state.inputHonorific} />
                        </div>
                    </div>

                    <div>
                        <div className = "input-field">
                            <label>Quantity</label>
                            <input type="number" name="inputEmailAddress" onChange={this.handleInputChange} value={this.state.inputEmailAddress}/>
                        </div>
                    </div>
                    </div>
                </div>
            </div>
        );
    }

}