import React from 'react'

export class AccountHistoryInput extends React.Component{

    render(){
        return(
            <div>
                <h3>Balance History</h3><br />
                <label>1 Month Ago</label><br />
                <input type="text" name="oneMonth" placeholder="Please enter a value" /><br /><br />

                <label>1 Year Ago</label><br />
                <input type="text" name="twoYear" placeholder="Please enter a value" /><br /><br />

                <label>3 Years Ago</label><br />
                <input type="text" name="threeYear" placeholder="Please enter a value" /><br /><br />

                <label>5 Years Ago</label><br />
                <input type="text" name="fiveYear" placeholder="Please enter a value" /><hr />

                <label>Value added this month</label><br />
                <input type="text" name="valThisMonth" placeholder="Please enter a value" /><br /><br />

                <label>Value added this year</label><br />
                <input type="text" name="valThisYear" placeholder="Please enter a value" /><br /><br />
            </div>
        );
    }

}