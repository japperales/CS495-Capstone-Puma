import React from 'react'
import { Tab, Tabs, TabList, TabPanel } from 'react-tabs';
import 'react-tabs/style/react-tabs.css';
import {CurrentAccountInput} from "./CurrentAccountInput";
import {AccountHistoryInput} from "./AccountHistoryInput";
import {AssetsInput} from "./AssetsInput";
import ReactTable from "react-table";

export class TabsPage extends React.Component {
   

    render() {
        return(
            <div>
                <Tabs>
                    <TabList>
                        <Tab>Account Info</Tab>
                        <Tab>Account History</Tab>
                        <Tab>Assets</Tab>
                    </TabList>

                    <TabPanel>
                        <CurrentAccountInput />
                    </TabPanel>
                    <TabPanel>
                        <AccountHistoryInput />
                    </TabPanel>
                    <TabPanel>
                        <AssetsInput />
                    </TabPanel>
                </Tabs>
                <button>Submit Info</button>
            </div>
        );
    }
}
