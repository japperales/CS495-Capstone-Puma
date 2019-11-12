import React, { Component } from 'react';

export class TestClient extends Component{
    
    constructor(props) {
        super(props);
        this.state={name : 'JP', age : 22, balance : 223888.49,
                            inputName: '', inputBalance: null, inputAge: null};
        /*fetch('api/ExampleClass/CoolGuyCreator')
            .then(response => response.json())
            .then(data => {
                this.setState({ name: data.name, job : data.job, age : data.age});
            });*/
        this.SendData = this.SendData.bind(this);
        this.handleInputChange = this.handleInputChange.bind(this);
    }

      SendData(event) {
          event.preventDefault();
          fetch('api/Main/ConvertData', {
              method: 'POST',
              headers: {
                  'Accept': 'application/json',
                  'Content-Type': 'application/json; charset=UTF-8',
              },
              body: JSON.stringify({
                  
                  name: this.state.inputName,
                  age: this.state.inputAge,
                  balance: this.state.inputBalance
              })
          }).then(response => response.json())
              .then(data => {
                  this.setState({ name: data.name, age : data.age, balance : data.balance,});
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
            <p>Here we have: {this.state.name}, he has ${this.state.balance} in his account, and he is {this.state.age} years old.</p>
            
            <form onSubmit={this.SendData}>
                <label>Guy Name</label>
                <br/>
                <input type="text" name="inputName" onChange={this.handleInputChange} value={this.state.inputName}/>
                <br/>
                <label>Guy Age</label>
                <br/>
                <input type="number" name="inputAge" onChange={this.handleInputChange} value={this.state.inputAge} />
                <br/>
                <label>Guy Balance</label>
                <br/>
                <input type="text" name="inputBalance" onChange={this.handleInputChange} value={this.state.inputBalance}/>
                <br/>
                <br/>
                <input type="submit" value="Submit" />
            </form>
            </div>);
    }
}
