import React, {component} from 'react' ;
import ReactJson from 'react-json-view'
import { Doughnut } from 'react-chartjs-2';
import Flexbox from 'flexbox-react';
import LoadingSpinner from './LoadingSpinner';
import {formatDoughnutChartValues} from "./ResultsParsing";
import MaterialTable from "material-table";
import {revisedPortfolioColumns, tradeColumns} from "./TableColumns";
import CountUp from 'react-countup';


let state = {loading: false, portfolioResponse: null, doughnutData: null, newDoughnutData: null};


export class Results extends React.Component{

    constructor(props) {
        super(props);
        this.readyToDisplayResults = this.readyToDisplayResults.bind(this);
        this.onClickWrapperMethod = this.onClickWrapperMethod.bind(this);
        this.isLoading = this.isLoading.bind(this);
        this.readyToBeginRetrieving = this.readyToBeginRetrieving.bind(this);
        this.state = {loading: false, portfolioResponse: state.portfolioResponse, doughnutData: state.doughnutData, newDoughnutData: state.newDoughnutData};
        
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
    
    //methods that return booleans to track the state of loading for the component.
    readyToDisplayResults(){
        return (!this.state.loading && this.props.portfolioResponse !== null);
    }
    
    readyToBeginRetrieving(){
        return !this.state.loading && this.props.portfolioResponse === null;
    }
    
    isLoading(){
        return this.state.loading && this.props.portfolioResponse === null;
    }
    
    StartLoading(){
        this.setState({loading: true})
    }
    
    //method to check to see if results props has changed. If results props has changed, then the component rerenders.
    componentWillReceiveProps(nextProps) {
        if (nextProps.portfolioResponse !== this.props.portfolioResponse) {
            this.setState({ portfolioResponse: nextProps.portfolioResponse,
                loading: false});
            this.forceUpdate();
        }
    }
    
    render() {
        if (this.readyToDisplayResults()) {
            if (this.state.doughnutData === null) {
                this.setState({doughnutData: formatDoughnutChartValues(this.state.portfolioResponse[0]),
                });
                this.setState({newDoughnutData: formatDoughnutChartValues(this.state.portfolioResponse[1])});
                
            }
            
            return (
                <div>
                    <a className={"waves-effect waves-light btn light-blue lighten-3"}>Log out</a>
                    <button className="waves-effect waves-light btn light-blue lighten-3" onClick={this.onClickWrapperMethod}>
                        Retrieve Again
                    </button>
                    <div className="container">
                        <div><CountUp start={100000}
                                      end={this.state.portfolioResponse[2]}
                                      duration={3}
                                      decimal={"."}
                                      decimals={2}
                                      separator=","
                                      prefix="$ "
                                      suffix=" Portfolio Value Increase"
                                      style={{color: "green", fontSize: "36px"}}/>
                            <br/>

                            <CountUp start={0}
                                     end={this.state.portfolioResponse[3]}
                                     duration={3}
                                     separator=","
                                     decimal={"."}
                                     decimals={2}
                                     prefix="$ "
                                     suffix=" Monthly Income Increase"
                                     style={{color: "green", fontSize: "36px", font: "lato"}}/>
                        <div className="row">
                            <div className="col s6">
                        <div><h3>Current Portfolio Composition</h3>
                            <Doughnut data={this.state.doughnutData}/></div>
                                <br/>
                                <div><MaterialTable title={"Original Portfolio"} columns={revisedPortfolioColumns} data={this.state.portfolioResponse[0]}
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
                            
                            
                            
                            <div className="col s6">
                                <h3>Proposed Portfolio Composition</h3>
                                <Doughnut data={this.state.newDoughnutData}/>
                        <br/>
                            <div><MaterialTable title={"Proposed Portfolio"} columns={revisedPortfolioColumns} data={this.state.portfolioResponse[1]}
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
                    </div>

                    </div>

                </div>
            )
        } else if (this.readyToBeginRetrieving()) {
            return (
                <div>
                    <h3>Results Comparison</h3>
                    <button className="waves-effect waves-light btn light-blue lighten-3" onClick={this.onClickWrapperMethod}>Retrieve Results
                    </button>
                </div>
            );
        }else
        {
            return(
                <div>
                    <h3>Loading Comparison, Please Wait</h3>
                    <button className="waves-effect waves-light btn light-blue lighten-3" onClick={this.onClickWrapperMethod}>Retrieve Results</button>
                    <LoadingSpinner/>
                </div>
                
            );
        }
    }
}
