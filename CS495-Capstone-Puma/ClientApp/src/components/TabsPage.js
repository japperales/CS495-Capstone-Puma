import React from 'react'
import { Tab, Tabs, TabList, TabPanel } from 'react-tabs';
import 'react-tabs/style/react-tabs.css';
import {PersonalInput} from "./PersonalInput";
import {BondInput} from "./BondInput";
import {MiscAssetInput} from "./MiscAssetInput";
import {LoanInput} from "./LoanInput";
import {MutualFundInput} from "./MutualFundInput";
import {StockInput} from "./StockInput";
import {Propertyinput} from "./Propertyinput";
import {Results} from "./Results"

export class TabsPage extends React.Component {

    constructor(props){
        super(props);
        this.state = {
            firstName: null,
            middleName: null,
            lastName: null,
            honorific: null,
            emailAddress: null,

            outputFirstName: null,
            outputMiddleName: null,
            outputLastName: null,
            outputHonorific: null,
            outputEmailAddress: null,

            bonds:[],
            misc:[],
            loans: [],
            mutualFunds: [],
            stocks: [],
            properties: [],

            outputIden: {
                "IdentityRecord": {
                    "IdentityRecordId": 0,
                    "Code": null,
                    "DisplayName": null,
                    "PayeeName": null,
                    "TaxIdStatusType": null,
                    "TaxId": null,
                    "TaxIdType": null,
                    "DomainModelClass": null,
                    "Comments": null,
                    "SalutationType": "this.state.honorific",
                    "GenderType": null,
                    "FirstNameLegalName": "this.state.firstName",
                    "MiddleName": "this.state.middleName",
                    "LastName": "this.state.lastName",
                    "Title": null,
                    "ContactName": null,
                    "DateOfBirth": null,
                    "DateOfDeath": null,
                    "PhoneNumbers": null,
                    "Emails": [
                        {
                            "EmailAddress": "this.state.emailAddress",
                            "IdentityRecordId": null,
                            "ContactMechanismId": null,
                            "ContactMechanismType": null,
                            "ContactMechanismUseType": null,
                            "IsPrimary": null,
                            "MonthEffectiveFrom": null,
                            "MonthEffectiveTo": null,
                            "DayEffectiveFrom": null,
                            "DayEffectiveTo": null,
                            "IsActive": null,
                            "Note": null,
                            "ContactMechanismPurposeTypes": null,
                            "InstitutionIdentityRecordId": null
                        }
                    ],
                    "Addresses": null,
                    "IdentityClassificationTypes": null,
                    "IsActive": false,
                    "InstitutionIdentityRecordId": null
                },
                "BondList": null,
                "MiscList": null,
                "LoanList": null,
                "MutualFundList": null,
                "StockList": null,
                "PropertyList": null,
                "Assets": [
                    {
                        "AssetId": 2,
                        "AssetCode": "string",
                        "AssetCodeType": "CUSIP",
                        "AssetCodeTypeName": "string",
                        "PortfolioReportCategoryId": 0,
                        "AssetCategory": "CommonStock",
                        "AssetCategoryDisplayName": "string",
                        "Symbol": "string",
                        "Issue": "string",
                        "Issuer": "string",
                        "IssueStatusType": "Active",
                        "IssueStatusTypeName": "string",
                        "StateProvince": "Alabama",
                        "StateProvinceAbbreviation": "string",
                        "Country": "UnitedStates",
                        "CountryName": "string",
                        "DomainModelClass": "IdentityRecord",
                        "DomainModelClassName": "string",
                        "TradeWhenInstitutionOpen": true,
                        "UpdateFromInterface": true,
                        "IraHardToValueType": "StockOrOtherOwnershipInterestInACorporationThatIsNotReadilyTradableOnAnEstablishedSecuritiesMarket",
                        "IraHardToValueTypeName": "string",
                        "IsActive": true,
                        "CreatedDate": "2019-11-17T23:56:00.071+00:00",
                        "ModifiedDate": "2019-11-17T23:56:00.071+00:00",
                        "ModifiedBy": "string",
                        "Stock": {
                            "IndustryId": 0,
                            "ExchangeType": "None",
                            "ExchangeTypeName": "string",
                            "EarningsPerShareDiluted": 0,
                            "EarningsPerShareBasic": 0,
                            "EarningsPerShareEffectiveDate": "2019-11-17T23:56:00.071+00:00",
                            "PaymentFrequencyType": "RunOnce",
                            "PaymentFrequencyTypeName": "string",
                            "SharesOutstanding": 0,
                            "IsIncludedIn13F": true,
                            "IsRestrictedByRule144A": true,
                            "CalculatedMarketCapType": "MicroCap",
                            "CalculatedMarketCapTypeName": "string"
                        },
                        "Bond": null,
                        "CashEquivalent": {
                            "QualityRating": "string",
                            "DateOfIssue": "2019-11-17T23:56:00.071+00:00",
                            "IncomePaymentFrequencyType": "RunOnce",
                            "IncomePaymentFrequencyTypeName": "string",
                            "IncomePaymentMonth": 0,
                            "IncomePaymentDay": 0,
                            "AmortizationFrequencyType": "RunOnce",
                            "AmortizationFrequencyTypeName": "string",
                            "AccrualMethodType": "DailyFactorSD",
                            "AccrualMethodTypeName": "string",
                            "CompoundingFrequencyType": "RunOnce",
                            "CompoundingFrequencyTypeName": "string",
                            "DepositoryIdentityRecordId": 0,
                            "StableNAV": true
                        },
                        "CertificateOfDeposit": {
                            "DateOfIssue": "2019-11-17T23:56:00.071+00:00",
                            "IncomePaymentFrequencyType": "RunOnce",
                            "IncomePaymentFrequencyTypeName": "string",
                            "IncomePaymentMonth": 0,
                            "IncomePaymentDay": 0,
                            "AmortizationFrequencyType": "RunOnce",
                            "AmortizationFrequencyTypeName": "string",
                            "AccrualMethodType": "DailyFactorSD",
                            "AccrualMethodTypeName": "string",
                            "CompoundingFrequencyType": "RunOnce",
                            "CompoundingFrequencyTypeName": "string",
                            "DepositoryIdentityRecordId": 0,
                            "DateOfMaturity": "2019-11-17T23:56:00.071+00:00",
                            "DateOfFirstPayment": "2019-11-17T23:56:00.071+00:00",
                            "OddLastCouponType": "NotSuppliedNormal",
                            "OddLastCouponTypeName": "string"
                        },
                        "MutualFund": {
                            "IncomePaymentFrequencyType": "RunOnce",
                            "IncomePaymentFrequencyTypeName": "string",
                            "IncomePaymentMonth": 0,
                            "IncomePaymentDay": 0,
                            "UseDailyFactor": true,
                            "AccrualMethodType": "DailyFactorSD",
                            "AccrualMethodTypeName": "string",
                            "ExchangeType": "None",
                            "ExchangeTypeName": "string",
                            "EarningsPerShareDiluted": 0,
                            "FundFamilyId": 0,
                            "FundCategoryId": 0,
                            "FundNumber": "string",
                            "FundStatusType": "Active",
                            "FundStatusTypeName": "string",
                            "ShortTermRedemptionFeePercent": 0,
                            "ShortTermHoldingPeriod": 0
                        },
                        "OtherAsset": {
                            "IncomePaymentFrequencyType": "RunOnce",
                            "IncomePaymentFrequencyTypeName": "string",
                            "IncomePaymentMonth": 0,
                            "IncomePaymentDay": 0,
                            "AmortizationFrequencyType": "RunOnce",
                            "AmortizationFrequencyTypeName": "string",
                            "AccrualMethodType": "DailyFactorSD",
                            "AccrualMethodTypeName": "string",
                            "CompoundingFrequencyType": "RunOnce",
                            "CompoundingFrequencyTypeName": "string",
                            "DepositoryIdentityRecordId": 0
                        },
                        "Option": {
                            "IndustryId": 0,
                            "ExchangeType": "None",
                            "ExchangeTypeName": "string",
                            "DateOfExpiration": "2019-11-17T23:56:00.071+00:00",
                            "AssociatedAssetId": 0,
                            "AssociatedAssetCode": "string",
                            "StrikePriceAmount": 0
                        },
                        "Property": {
                            "IncomePaymentFrequencyType": "RunOnce",
                            "IncomePaymentFrequencyTypeName": "string",
                            "IncomePaymentMonth": 0,
                            "IncomePaymentDay": 0,
                            "RealEstateParcelNumber": "string",
                            "InsurancePolicyNumber": "string"
                        },
                        "Loan": {
                            "DateOfIssue": "2019-11-17T23:56:00.071+00:00",
                            "DateOfMaturity": "2019-11-17T23:56:00.071+00:00",
                            "DateOfFirstPayment": "2019-11-17T23:56:00.071+00:00",
                            "OddLastCouponType": "NotSuppliedNormal",
                            "OddLastCouponTypeName": "string",
                            "PaymentFrequencyType": "RunOnce",
                            "PaymentFrequencyTypeName": "string",
                            "IncomePaymentFrequencyType": "RunOnce",
                            "IncomePaymentFrequencyTypeName": "string",
                            "IncomePaymentMonth": 0,
                            "IncomePaymentDay": 0,
                            "CompoundingFrequencyType": "RunOnce",
                            "CompoundingFrequencyTypeName": "string",
                            "AmortizationFrequencyType": "RunOnce",
                            "AmortizationFrequencyTypeName": "string",
                            "AccrualMethodType": "DailyFactorSD",
                            "AccrualMethodTypeName": "string",
                            "DepositoryIdentityRecordId": 0,
                            "LenderIdentityRecordId": 0,
                            "BorrowerIdentityRecordId": 0,
                            "PeriodicPaymentAmount": 0,
                            "ExcludeFromDelinquencyReporting": true,
                            "DateExcludeFromDelinquencyExpiration": "2019-11-17T23:56:00.071+00:00"
                        },
                        "DailyFactors": [
                            {
                                "DailyFactorId": 0,
                                "Factor": 0,
                                "DateEffectiveFrom": "2019-11-17T23:56:00.071+00:00",
                                "DateEffectiveTo": "2019-11-17T23:56:00.071+00:00",
                                "CreatedDate": "2019-11-17T23:56:00.071+00:00",
                                "ModifiedDate": "2019-11-17T23:56:00.071+00:00",
                                "ModifiedBy": "string"
                            }
                        ],
                        "DividendEvents": [
                            {
                                "DividendPaymentType": "OrdinaryDividend",
                                "DividendPaymentTypeName": "string",
                                "DividendAmountPerShare": 0,
                                "DividendStockPerShare": 0,
                                "DividendSplitRatio": "string",
                                "IndicatedAnnualDividendPerShare": 0,
                                "DateExDividend": "2019-11-17T23:56:00.071+00:00",
                                "DateOfRecord": "2019-11-17T23:56:00.071+00:00",
                                "DateOfPayment": "2019-11-17T23:56:00.071+00:00",
                                "DateAnnounced": "2019-11-17T23:56:00.071+00:00",
                                "EventCode": "string",
                                "EventRevisionCode": "string",
                                "IsActive": true,
                                "CreatedDate": "2019-11-17T23:56:00.071+00:00",
                                "ModifiedDate": "2019-11-17T23:56:00.071+00:00",
                                "ModifiedBy": "string"
                            }
                        ],
                        "InterestRates": [
                            {
                                "InterestRateId": 0,
                                "Rate": 0,
                                "DateEffectiveFrom": "2019-11-17T23:56:00.071+00:00",
                                "DateEffectiveTo": "2019-11-17T23:56:00.071+00:00",
                                "CreatedDate": "2019-11-17T23:56:00.071+00:00",
                                "ModifiedDate": "2019-11-17T23:56:00.071+00:00",
                                "ModifiedBy": "string"
                            }
                        ],
                        "PoolFactors": [
                            {
                                "Factor": 0,
                                "DateEffectiveFrom": "2019-11-17T23:56:00.071+00:00",
                                "DateEffectiveTo": "2019-11-17T23:56:00.071+00:00",
                                "CreatedDate": "2019-11-17T23:56:00.071+00:00",
                                "ModifiedDate": "2019-11-17T23:56:00.071+00:00",
                                "ModifiedBy": "string",
                                "PoolFactorId": 0,
                                "PaymentDelay": 0
                            }
                        ],
                        "PriceHistories": [
                            {
                                "PriceHistoryId": 0,
                                "Price": 0,
                                "Volume": 0,
                                "AskPrice": 0,
                                "BidPrice": 0,
                                "PricingSourceId": 0,
                                "DateEffectiveFrom": "2019-11-17T23:56:00.071+00:00",
                                "DateEffectiveTo": "2019-11-17T23:56:00.071+00:00",
                                "CreatedDate": "2019-11-17T23:56:00.071+00:00",
                                "ModifiedDate": "2019-11-17T23:56:00.071+00:00",
                                "ModifiedBy": "string"
                            }
                        ],
                        "QualityRatingHistories": [
                            {
                                "QualityRatingHistoryId": 0,
                                "QualityRatingSourceId": 0,
                                "QualityRating": "string",
                                "DateEffectiveFrom": "2019-11-17T23:56:00.072+00:00",
                                "DateEffectiveTo": "2019-11-17T23:56:00.072+00:00",
                                "CreatedDate": "2019-11-17T23:56:00.072+00:00",
                                "ModifiedDate": "2019-11-17T23:56:00.072+00:00",
                                "ModifiedBy": "string"
                            }
                        ],
                        "AssetInstitutionSettings": [
                            {
                                "AssetInstitutionSettingsId": 0,
                                "InstitutionIdentityRecordId": 0,
                                "OverridePortfolioReportCategoryId": 0,
                                "OverrideIndustryId": 0,
                                "MarketCapType": "MicroCap",
                                "MarketCapTypeName": "string",
                                "UnitDecimal": 0,
                                "ApprovedListRuleType": "UseRules",
                                "ApprovedListRuleTypeName": "string",
                                "CreatedDate": "2019-11-17T23:56:00.072+00:00",
                                "ModifiedDate": "2019-11-17T23:56:00.072+00:00",
                                "ModifiedBy": "string",
                                "AssetInstitutionSettingsCustomFields": [
                                    {
                                        "CustomFieldId": 0,
                                        "FieldName": "string",
                                        "LabelName": "string",
                                        "Value": "string",
                                        "IsRequired": true,
                                        "ModifiedDate": "2019-11-17T23:56:00.072+00:00",
                                        "ModifiedBy": "string",
                                        "CreatedDate": "2019-11-17T23:56:00.072+00:00"
                                    }
                                ]
                            }
                        ]
                    }
                ]
            }
        };
        this.personalCallback = this.personalCallback.bind(this);
        this.bondCallback = this.bondCallback.bind(this);
        this.miscCallback = this.miscCallback.bind(this);
        this.loanCallback = this.loanCallback.bind(this);
        this.mutualFundCallback = this.mutualFundCallback.bind(this);
        this.stockCallback = this.stockCallback.bind(this);
        this.propertyCallback = this.propertyCallback.bind(this);
        this.sendPortfolio = this.sendPortfolio.bind(this);
    }

    personalCallback(firstName, middleName, lastName, honorific, emailAddress){
        this.setState({firstName: firstName, middleName: middleName, lastName: lastName, honorific: honorific, emailAddress: emailAddress});

    }

    bondCallback(assets){
        this.setState({bonds: assets});
    }

    miscCallback(assets){
        this.setState({misc: assets});
    }

    loanCallback(assets){
        this.setState({loans: assets});
    }

    mutualFundCallback(assets){
        this.setState({mutualFunds: assets});
    }

    stockCallback(assets){
        this.setState({stocks: assets});
    }

    propertyCallback(assets){
        this.setState({properties: assets});
    }

    sendPortfolio(event) {
        event.preventDefault();
        fetch('api/Puma', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json; charset=UTF-8',
            },
            body: JSON.stringify({
                IdentityRecord: {
                    firstNameLegalName: this.state.firstName,
                    middleName: this.state.middleName,
                    lastName: this.state.lastName,
                    salutationType: this.state.honorific,
                    emails: [{emailAddress: this.state.emailAddress}],
                },
                BondList: this.state.bonds,
                MiscList: this.state.misc,
                LoanList: this.state.loans,
                MutualFundList: this.state.mutualFunds,
                StockList: this.state.stocks,
                PropertyList: this.state.properties
            })
        }).then(response => response.json())
            .then(data => {
                this.setState({outputIden: data});
            });
    }

    render() {
        return(
            <div>
                <Tabs>
                    <TabList>
                        <Tab>Personal Info</Tab>
                        <Tab>Bonds</Tab>
                        <Tab>Miscellaneous Assets</Tab>
                        <Tab>Loans</Tab>
                        <Tab>Mutual Funds</Tab>
                        <Tab>Stocks</Tab>
                        <Tab>Properties</Tab>
                        <Tab>Results</Tab>
                    </TabList>

                    <TabPanel>
                        <PersonalInput personalCallback={this.personalCallback}/>
                    </TabPanel>
                    <TabPanel>
                        <BondInput bondCallback={this.bondCallback}/>
                    </TabPanel>
                    <TabPanel>
                        <MiscAssetInput miscCallback={this.miscCallback}/>
                    </TabPanel>
                    <TabPanel>
                        <LoanInput loanCallback={this.loanCallback}/>
                    </TabPanel>
                    <TabPanel>
                        <MutualFundInput mutualFundCallback={this.mutualFundCallback}/>
                    </TabPanel>
                    <TabPanel>
                        <StockInput stockCallback={this.stockCallback}/>
                    </TabPanel>
                    <TabPanel>
                        <Propertyinput propertyCallback={this.propertyCallback}/>
                    </TabPanel>
                    <TabPanel>
                        <Results outputIden={this.state.outputIden}/>
                    </TabPanel>
                </Tabs>
                <button onClick={this.sendPortfolio}>Submit Info</button>
                Here is my example of props and callbacks: currently, the first name is: {this.state.firstName}, the middle name is: {this.state.middleName}, the last name is: {this.state.lastName}, the honorific is: {this.state.honorific}, the email is: {this.state.emailAddress}
                <br/> OUTPUT: {this.state.outputFirstName}, <br/>
                <br/>{this.state.outputMiddleName},
                <br/>{this.state.outputLastName}, {this.state.outputHonorific}, {this.state.outputEmailAddress}
                <br/><br/>BONDS: {JSON.stringify(this.state.bonds)},
                <br/><br/>MISC: {JSON.stringify(this.state.misc)},
                <br/><br/>LOANS: {JSON.stringify(this.state.loans)},
                <br/><br/>MUTUAL FUNDS: {JSON.stringify(this.state.mutualFunds)},

                <br/><br/>STOCKS: {JSON.stringify(this.state.stocks)},
                <br/><br/>PROPERTIES: {JSON.stringify(this.state.properties)}
            </div>
        );
    }
}
