import React from 'react'
import { Tab, Tabs, TabList, TabPanel } from 'react-tabs';
import 'react-tabs/style/react-tabs.css';
import {PersonalInput} from "./PersonalInput";
import {AccountHistoryInput} from "./AccountHistoryInput";
import {AssetsInput} from "./AssetsInput";
import {BondInput} from "./BondInput";
import {MiscAssetInput} from "./MiscAssetInput";

export class TabsPage extends React.Component {

    render() {
        return(
            <div>
                <Tabs>
                    <TabList>
                        <Tab>Personal Info</Tab>
                        <Tab>Account History</Tab>
                        <Tab>Assets</Tab>
                        <Tab>Bonds</Tab>
                        <Tab>Miscellaneous Assets</Tab>
                    </TabList>

                    <TabPanel>
                        <PersonalInput />
                    </TabPanel>
                    <TabPanel>
                        <AccountHistoryInput />
                    </TabPanel>
                    <TabPanel>
                        <AssetsInput />
                    </TabPanel>
                    <TabPanel>
                        <BondInput />
                    </TabPanel>
                    <TabPanel>
                        <MiscAssetInput />
                    </TabPanel>
                </Tabs>
                <button>Submit Info</button>
            </div>
        );
    }
}
