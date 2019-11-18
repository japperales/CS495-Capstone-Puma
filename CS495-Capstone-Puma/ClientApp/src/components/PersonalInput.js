import React from 'react';

let state ={
    inputFirstName: null,
    inputMiddleName: null,
    inputLastName: null,
    inputHonorific: null,
    inputEmailAddress:null
};

export class PersonalInput extends React.Component{
    
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
            <div>
                <h3>Account Holder Information</h3> 
                <br />
                
                <label>First Name</label>
                <br />
                <input type="text" name="inputFirstName" onChange={this.handleInputChange} value={this.state.inputFirstName}/>
                <br />
                <br />
                
                <label>Middle Name</label>
                <br />
                <input type="text" name="inputMiddleName" onChange={this.handleInputChange} value={this.state.inputMiddleName}/>
                <br />
                <br />
                
                <label>Last Name</label>
                <br />
                <input type="text" name="inputLastName" onChange={this.handleInputChange} value={this.state.inputLastName}/>
                <br />
                <br />
                
                <label>Honorific</label>
                <br />
                <select name="inputHonorific" onChange={this.handleInputChange}  value={this.state.inputHonorific}>
                    <option value="Mr">Mr</option>
                    <option value="Mrs">Mrs</option>
                    <option value="Ms">Ms</option>
                    <option value="Dr">Dr</option>
                    <option value="" selected="selected"> </option>
                </select>
                <br />
                <br />
                
                <label>Email</label>
                <br />
                <input type="text" name="inputEmailAddress" onChange={this.handleInputChange} value={this.state.inputEmailAddress}/>
                <br />
                <br />
                <hr />
            </div>
        );
    }
    
}