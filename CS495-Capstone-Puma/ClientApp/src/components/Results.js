import React, {component} from 'react' ;
import ReactJson from 'react-json-view'
import { Doughnut } from 'react-chartjs-2';
import Flexbox from 'flexbox-react';
import LoadingSpinner from './LoadingSpinner';
import {formatDoughnutChartValues} from "./ResultsParsing";
import MaterialTable from "material-table";
import {portfolioColumns, tradeColumns} from "./TableColumns";
import CountUp from 'react-countup';
import {lightgreen} from "color-name";


let state = {loading: false, stateOutputIden: null, doughnutData: null};


export class Results extends React.Component{

    constructor(props) {
        super(props);
        this.readyToDisplayResults = this.readyToDisplayResults.bind(this);
        this.onClickWrapperMethod = this.onClickWrapperMethod.bind(this);
        this.isLoading = this.isLoading.bind(this);
        this.readyToBeginRetrieving = this.readyToBeginRetrieving.bind(this);
        this.state = {loading: false, stateOutputIden: state.stateOutputIden, doughnutData: state.doughnutData};
        
    }


    componentDidMount() {
       this.state = state;
    }
    componentWillUnmount(){
        state = this.state;
    }
    
    onClickWrapperMethod(event){
        event.preventDefault();
        this.props.sendPortfolio(event);
        this.StartLoading();
        this.forceUpdate()
    }
    
    readyToDisplayResults(){
        return !this.state.loading && this.props.outputIden!==null;
    }
    
    readyToBeginRetrieving(){
        return !this.state.loading && this.props.outputIden === null;
    }
    
    componentWillReceiveProps(nextProps) {
        if (nextProps.outputIden !== this.props.outputIden) {
            this.setState({ stateOutputIden: nextProps.outputIden,
                                loading: false});
            this.forceUpdate();
        }
    }
    
    isLoading(){
        return this.state.loading && this.props.outputIden === null;
    }
    
    StartLoading(){
        this.setState({loading: true})
    }
    
    render() {
        if (this.readyToDisplayResults()) {
            if (this.state.doughnutData ===null) {
                this.state.doughnutData = formatDoughnutChartValues(this.state.stateOutputIden[0]);
            }
            
            return (
                <div>
                    <button className="waves-effect waves-light btn" onClick={this.onClickWrapperMethod}>Submit Info
                    </button>
                    <div style={{ display: "grid", gridTemplateColumns: "repeat(auto-fill, 1fr)", gridGap: 20 }}>
                        <div><h3>Current Portfolio Composition</h3>
                            <Doughnut data={this.state.doughnutData}/></div>
                        <div><CountUp start={0}
                                      end={this.state.stateOutputIden[2]}
                                      duration={3}
                                      decimals={2}
                                      prefix="+$"
                                      suffix=" Portfolio Value Increase"
                                      style={{color: "green", fontSize: "36px"}}/>
                            <br/>
                            <CountUp start={0}
                                     end={this.state.stateOutputIden[3]}
                                     duration={3}
                                     decimals={2}
                                     prefix="+$"
                                     suffix=" Monthly Income Increase"
                                     style={{color: "green", fontSize: "36px"}}/>
                        </div>
                    </div>
                    <div style={{ display: "grid", gridTemplateColumns: "repeat(auto-fill, 1fr)", gridGap: 20 }}>
                        <div><MaterialTable title={"Original Portfolio"} columns={portfolioColumns} data={this.state.stateOutputIden[0]}
                                            options={{
                                                rowStyle: {
                                                    fontSize: '14px',
                                                    fontFamily: 'sans-serif',
                                                    textAlign: 'center',
                                                    backgroundColor: 'aliceblue'
                                                },

                                                headerStyle: {
                                                    backgroundColor: 'skyblue',
                                                    color: '#FFF',
                                                    fontSize: '14px',
                                                    fontFamily: 'sans-serif',
                                                    borderRadius: '0px',
                                                }
                                            }
                                            }/></div>
                        <div><MaterialTable title={"Proposed Trades"} columns={tradeColumns} data={this.state.stateOutputIden[1]}
                                            options={{
                                                rowStyle: {
                                                    fontSize: '14px',
                                                    fontFamily: 'sans-serif',
                                                    textAlign: 'center',
                                                    backgroundColor: 'aliceblue'
                                                },

                                                headerStyle: {
                                                    backgroundColor: 'skyblue',
                                                    color: '#FFF',
                                                    fontSize: '14px',
                                                    fontFamily: 'sans-serif',
                                                    borderRadius: '0px',
                                                }
                                            }
                                            }/></div>

                    </div>

                </div>
            )
        } else if (this.readyToBeginRetrieving()) {
            return (
                <div>
                    <button className="waves-effect waves-light btn" onClick={this.onClickWrapperMethod}>Submit Info
                    </button>
                </div>
            );
        }else
        {
            return(
                <div>
                <button className="waves-effect waves-light btn" onClick={this.onClickWrapperMethod}>Submit Info</button>
                <LoadingSpinner/>
                </div>
                
            );
        }
    }
}
