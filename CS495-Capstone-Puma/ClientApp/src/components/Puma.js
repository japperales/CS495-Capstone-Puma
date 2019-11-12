import React, {component} from 'react' ;

export class Puma extends React.Component{
    displayName=Puma.name

    constructor(props) {
        super(props)
        this.state = {
            assets: [
                { name: 'test1', price: '45.5', quantity: 21 },
                { name: 'test2', price: '23.4', quantity: 45 },
                { name: 'test3', price: '13.8', quantity: 64 },
                { name: 'test4', price: '12', quantity: 32 }
            ]
        }
    }
    renderTableHeader() {
        let header = Object.keys(this.state.assets[0])
        return header.map((key, index) => {
            return <th key={index}>{key.toUpperCase()}</th>
        })
    }
    renderTableData() {
        return this.state.assets.map((asset, index) => {
            const { name, price, quantity } = asset
            return (
                <tr key={name}>
                    <td>{name}</td>
                    <td>{price}</td>
                    <td>{quantity}</td>
                </tr>
            )
        })
    }
    
    render() {
        return (
            <form>
                <div>
                    <h1>Puma - Iteration 1</h1><hr />
                    <label>Start Date</label><br />
                    <input type="date" name="startDate" /><br /><br />

                    <label>End Date</label><br />
                    <input type="date" name="endDate" /><br /><br />

                    <label>Current Account Value</label><br />
                    <input type="text" name="accountValue" placeholder="Please enter a value" /><hr />

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

                    <label>Planned yearly retirement spending</label><br />
                    <input type="text" name="retSpending" placeholder="Please enter a value" /><br /><br />
                    <hr />

                    <h3 id='title'>Assets</h3>
                    <table className='table' id='assets'>
                        <tbody>
                        <tr>{this.renderTableHeader()}</tr>
                        {this.renderTableData()}
                        </tbody>
                    </table>

                    <input type="submit" value="Submit" /><br />
                    <button type="reset">Reset</button>



                </div>
            </form>
        );

    }

}