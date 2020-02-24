import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import {TabsPage} from "./components/TabsPage";

export default class App extends Component {
    displayName = App.name;

    render() {
        return (
            
            <Layout>
                <Route path='/TabsPage' component={TabsPage} />
            </Layout>
            
        );
    }
}
