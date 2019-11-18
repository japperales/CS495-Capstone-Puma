import React, { Component } from 'react';

export class TestClient extends Component{
    
    constructor(props) {
        super(props);
        this.state={identityRecordId : 6, displayName : "Test",
                            inputIdentityRecordId: null, inputName:"", resp:""};
        this.SendData = this.SendData.bind(this);
        this.handleInputChange = this.handleInputChange.bind(this);
    }

      SendData(event) {
          event.preventDefault();
          fetch('api/Main', {
              method: 'POST',
              headers: {
                  'Accept': 'application/json',
                  'Content-Type': 'application/json; charset=UTF-8',
              },
              body: JSON.stringify({
                  
                  identityRecordId: this.state.inputIdentityRecordId,
                  displayName: this.state.inputName,
              })
          }).then(response => response.json())
              .then(data => {
                  this.setState({resp: JSON.stringify(data)});
                  this.setState({ identityRecordId: data.IdentityRecordId, displayName : data.DisplayName});
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
            <p>Record no {this.state.identityRecordId}, display name: {this.state.displayName}.{this.state.resp}</p>
            
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
                <input type="text" name="inputBalance" onChange={this.handleInputChange} value={0}/>
                <br/>
                <br/>
                <input type="submit" value="Submit" />
            </form>
            </div>);
    }
}
