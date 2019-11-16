import React from 'react'
import { Tab, Tabs, TabList, TabPanel } from 'react-tabs';
import 'react-tabs/style/react-tabs.css';
import {PersonalInput} from "./PersonalInput";
import {AccountHistoryInput} from "./AccountHistoryInput";
import {AssetsInput} from "./AssetsInput";
import {BondInput} from "./BondInput";
import {MiscAssetInput} from "./MiscAssetInput";
import {LoanInput} from "./LoanInput";
import {MutualFundInput} from "./MutualFundInput";
import {StockInput} from "./StockInput";
import {Propertyinput} from "./Propertyinput";

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
                        <Tab>Loans</Tab>
                        <Tab>Mutual Funds</Tab>
                        <Tab>Stocks</Tab>
                        <Tab> Properties</Tab>
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
                    <TabPanel>
                        <LoanInput />
                    </TabPanel>
                    <TabPanel>
                        <MutualFundInput />
                    </TabPanel>
                    <TabPanel>
                        <StockInput />
                    </TabPanel>
                    <TabPanel>
                        <Propertyinput />
                    </TabPanel>
                </Tabs>
                <button>Submit Info</button>
            </div>
        );
    }
}
