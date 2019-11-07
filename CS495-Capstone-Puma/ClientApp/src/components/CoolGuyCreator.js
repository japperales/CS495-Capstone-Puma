import React, { Component } from 'react';

export class CoolGuyCreator extends Component{
    
    constructor(props) {
        super(props);
        this.state={name : "NULLNAME", job :"NULLJOB", age : -999999};
        /*fetch('api/ExampleClass/CoolGuyCreator')
            .then(response => response.json())
            .then(data => {
                this.setState({ name: data.name, job : data.job, age : data.age});
            });*/
        this.SendLoser = this.SendLoser.bind(this);
        
    }

      SendLoser() {
          fetch('api/ExampleClass/ConvertLoser', {
              method: 'POST',
              headers: {
                  'Accept': 'application/json',
                  'Content-Type': 'application/json',
              },
              body: JSON.stringify({
                  
                  name:'Cool King',
                  age: 45,
                  job : 'Burger Sommelier'
              })
          }).then(response => response.json())
              .then(data => {
                  this.setState({ name: data.name, job : data.job, age : data.age});
              });
    }
        
    
    render()
    {       this.SendLoser();
        return(<div>
            <p>Welcome to the cool guy creator! Make your cool guy by entering in your guy and watch him turn into a COOL guy!</p><br/>
            <p>Here we have: {this.state.name}, he is a: {this.state.job}, and he is: {this.state.age} years old.</p>
            
            <form>
                <label>Guy Name</label>
                <br/>
                <input type="text" name="Guy Name"/>
                <br/>
                <label>Guy Age</label>
                <br/>
                <input type="text" name="Guy Age"/>
                <br/>
                <label>Guy Job</label>
                <br/>
                <input type="text" name="Guy Job"/>
                <br/>
                <br/>
                <button >button?</button>
            </form>
            </div>);
    }
}
