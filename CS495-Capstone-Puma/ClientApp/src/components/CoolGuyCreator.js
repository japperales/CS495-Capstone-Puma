import React, { Component } from 'react';
import {AssetsInput} from "./AssetsInput";

export class CoolGuyCreator extends Component{
    
    constructor(props) {
        super(props);
        this.state={name : 'JP', job : 'Professional Coolest Guy', age : 22,
                            inputName: '', inputJob: '', inputAge: null};
        this.SendLoser = this.SendLoser.bind(this);
        this.handleInputChange = this.handleInputChange.bind(this);
    }

      SendLoser(event) {
          event.preventDefault();
          fetch('api/ExampleClass/ConvertLoser', {
              method: 'POST',
              headers: {
                  'Accept': 'application/json',
                  'Content-Type': 'application/json; charset=UTF-8',
              },
              body: JSON.stringify({
                  
                  name: this.state.inputName,
                  age: this.state.inputAge,
                  job: this.state.inputJob
              })
          }).then(response => response.json())
              .then(data => {
                  this.setState({ name: data.name, job : data.job, age : data.age});
              });
    }
    
    
        
    handleInputChange(event){
        
        const target = event.target;
        const value = event.target.value;
        const name = target.name;
    
        this.setState({
            [name]: value
        });
        
    }
    
    render()
    {       
        return(<div>
            <p>Welcome to the cool guy creator! Make your cool guy by entering in your guy and watch him turn into a COOL guy!</p><br/>
            <p>Here we have: {this.state.name}, he is a: {this.state.job}, and he is: {this.state.age} years old.</p>
            
            <form onSubmit={this.SendLoser}>
                <label>Guy Name</label>
                <br/>
                <input type="text" name="inputName" onChange={this.handleInputChange} value={this.state.inputName}/>
                <br/>
                <label>Guy Age</label>
                <br/>
                <input type="number" name="inputAge" onChange={this.handleInputChange} value={this.state.inputAge} />
                <br/>
                <label>Guy Job</label>
                <br/>
                <input type="text" name="inputJob" onChange={this.handleInputChange} value={this.state.inputJob}/>
                <br/>
                <br/>
                <input type="submit" value="Submit" />
            </form>
            </div>);
    }
}
