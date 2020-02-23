import React from 'react';
import MaterialTable from 'material-table';


export default class DeleteableTable extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <MaterialTable
                title=" "
                columns={this.props.columns}
                data={this.props.data}
                editable={{
                    onRowDelete: oldData =>
                        new Promise((resolve, reject) => {
                            setTimeout(() => {
                                {
                                    let data =[...this.props.data];
                                    const index = data.indexOf(oldData);
                                    data.splice(index, 1);
                                    this.props.setParentData(data);
                                }
                                resolve()
                            }, 1000)
                        }),
                }}
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
                }
            />
        )
    }
}
  