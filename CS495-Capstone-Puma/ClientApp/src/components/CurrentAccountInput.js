import React from 'react'

export class CurrentAccountInput extends React.Component{
    
    render(){
        return(
            <div>
                <h3>Current Account Info</h3> 
                <br />
                <label> Statement Start Date</label>
                <br />
                <input type="date" name="startDate" />
                <br />
                <br />
                <label>Statement End Date</label>
                <br />
                <input type="date" name="endDate" />
                <br />
                <br />
                <label>Current Account Value</label><br />
                <input type="text" name="accountValue" placeholder="Please enter a value" /><hr />
            </div>
        );
    }
    
}