import React, {component} from 'react' ;

export class Results extends React.Component{
    
    
    render() {
        return (
            <div>
                <h2>Results</h2>
                <p name="texta" id="4" cols="50" rows="20">{this.props.outputIden}test</p>
            </div>
        );
    }
}