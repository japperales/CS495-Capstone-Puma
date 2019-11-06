import React, { Component } from 'react';

export class CoolGuyCreator extends Component{
    constructor(props) {
        super(props);
        
        this.state={Name : "NULLNAME", Job :"NULLJOB", Age : -999999};
        
        fetch('api/ExampleClass/CoolGuyCreator')
            .then(response => response.json())
            .then(data => {
                this.setState({ Name: data.name, Job : data.job, Age : data.age, Response : data.stringify});
            });
        
    }
    
    
    render()
    {
        return(<div>
            <p>Welcome to the cool guy creator! Make your cool guy by entering in your guy and watch him turn into a COOL guy!</p><br/>
            <p>Here we have: {this.state.Name}, he is a: {this.state.Job}, and he is: {this.state.Age} years old.</p>
            
            
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
                <input type="submit" value="Submit"/>
            </form>  
            </div>);
    }
}
