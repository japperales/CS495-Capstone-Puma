import React, {component} from 'react' ;
import ReactJson from 'react-json-view'

export class Results extends React.Component{
    render() {
        return (
            <div>
                <h3>Results</h3>
                <ReactJson src={this.props.outputIden} />
            </div>

        );
    }
}
