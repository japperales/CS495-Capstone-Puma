import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import {CoolGuyCreator} from "./components/CoolGuyCreator";
import {Puma} from "./components/Puma";
import { TabsPage } from "./components/TabsPage"

export default class App extends Component {
  displayName = App.name

  render() {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
        <Route path='/fetchdata' component={FetchData} />
        <Route path='/coolguycreator' component={CoolGuyCreator} />
        <Route path='/puma' component={Puma} />
        <Route path='/tabspage' component={TabsPage} />
      </Layout>
    );
  }
}
