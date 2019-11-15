import React from 'react';


export class PersonalInput extends React.Component{
    
    render(){
        return(
            <div>
                <h3>Account Holder Information</h3> 
                <br />
                
                <label>First Name</label>
                <br />
                <input type="text" name="firstName" />
                <br />
                <br />
                
                <label>Middle Name</label>
                <br />
                <input type="text" name="middleName" />
                <br />
                <br />
                
                <label>Last Name</label>
                <br />
                <input type="text" name="lastName" />
                <br />
                <br />
                
                <label>Honorific</label>
                <br />
                <select>
                    <option value="Mr">Mr</option>
                    <option value="Mrs">Mrs</option>
                    <option value="Ms">Ms</option>
                    <option value="Dr">Dr</option>
                </select>
                <br />
                <br />
                
                <label>Email</label>
                <br />
                <input type="text" name="emailAddress" />
                <br />
                <br />
                <hr />
            </div>
        );
    }
    
}