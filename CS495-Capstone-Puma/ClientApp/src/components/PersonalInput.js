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
                <div className = "row">
                    <div className = "input-field col s6">
                        <label>First Name</label>
                        <input type="text" name="inputFirstName" onChange={this.handleInputChange} value={this.state.inputFirstName}/>
                    </div>
                </div>

                <div className = "row">
                    <div className = "input-field col s6">
                        <label>Middle Name</label>
                        <input type="text" name="inputMiddleName" onChange={this.handleInputChange} value={this.state.inputMiddleName}/>
                    </div>
                </div>

                <div className = "row">
                    <div className = "input-field col s6">
                        <label>Last Name</label>
                        <input type="text" name="inputLastName" onChange={this.handleInputChange} value={this.state.inputLastName}/>
                    </div>
                </div>

                <div className="row">
                    <div className = "input-field col s6">
                        <select name="inputHonorific" onChange={this.handleInputChange}  value={this.state.inputHonorific}>
                            <option value="" disabled selected> </option>
                            <option value="Mr">Mr</option>
                            <option value="Mrs">Mrs</option>
                            <option value="Ms">Ms</option>
                            <option value="Dr">Dr</option>

                        </select>
                        <label>Honorific</label>
                    </div>
                </div>

                <div className = "row">
                    <div className = "input-field col s6">
                        <label>Email</label>
                        <input type="text" name="inputEmailAddress" onChange={this.handleInputChange} value={this.state.inputEmailAddress}/>
                    </div>
                </div>
            </div>
        );
    }

}