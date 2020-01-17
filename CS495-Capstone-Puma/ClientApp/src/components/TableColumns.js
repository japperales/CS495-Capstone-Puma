export const bondColumns = [
    { title: 'Name', field: 'name', initialEditValue: 'name' },
    { title: 'Price', field: 'price', initialEditValue: '0', type: 'numeric' },
    { title: 'Quantity', field: 'quantity', initialEditValue: '1', type: 'numeric' },
    { title: 'Date of Issue', field: 'dateOfIssue', type: 'date' },
    { title: 'Date of Maturity', field: 'dateOfMaturity', type: 'date' },
    { title: 'Income (Month)', field: 'incomePaymentMonth', initialEditValue: '0', type: 'numeric' },
    { title: 'Income (Day)', field: 'incomePaymentDay', initialEditValue: '0', type: 'numeric' },
    { title: 'Accrual Method', field: 'accrualMethod', initialEditValue: 'Type' },
    { title: 'Call Date', field: 'callDate', type: 'date' },
    { title: 'Call Price', field: 'callPrice', initialEditValue: '0', type: 'numeric' },
    { title: 'Date of First Payment', field: 'dateOfIssue', type: 'date' }
];

export const loanColumns = [
    { title: 'Name', field: 'name', initialEditValue: 'name' },
    { title: 'Price', field: 'price', initialEditValue: '0', type: 'numeric' },
    { title: 'Quantity', field: 'quantity', initialEditValue: '1', type: 'numeric' },
    { title: 'Date of Issue', field: 'dateOfIssue', type: 'date' },
    { title: 'Date of Maturity', field: 'dateOfMaturity', type: 'date' },
    { title: 'Date of First Payment', field: 'dateOfFirstPayment', type: 'date' },
    { title: 'Income (Month)', field: 'incomePaymentMonth', initialEditValue: '0', type: 'numeric' },
    { title: 'Income (Day)', field: 'incomePaymentDay', initialEditValue: '0', type: 'numeric' },
    { title: 'Accrual Method', field: 'accrualMethod', initialEditValue: 'Type' },
    { title: 'Payment Frequency', field: 'paymentFrequencyType', initialEditValue: 'Type' },
    { title: 'Compounding Frequency Type', field: 'compoundingFrequencyType', initialEditValue: 'Type' },
    { title: 'Amortization Frequency Type', field: 'amortizationFrequencyType', initialEditValue: 'Type' },
    { title: 'Call Date', field: 'callDate', type: 'date' }
];

export const mutualFundColumns = [
    { title: 'Name', field: 'name', initialEditValue: 'name' },
    { title: 'Price', field: 'price', initialEditValue: '0', type: 'numeric' },
    { title: 'Quantity', field: 'quantity', initialEditValue: '1', type: 'numeric' },
    { title: 'Income Payment Frequency', field: 'incomePaymentFrequencyType', initialEditValue: '0', type: 'numeric' },
    { title: 'Income (Day)', field: 'incomePaymentDay', initialEditValue: '0', type: 'numeric' },
    { title: 'Income (Month)', field: 'incomePaymentMonth', initialEditValue: '0', type: 'numeric' },
    { title: 'Uses Daily Factor', field: 'usesDailyFactor', initialEditValue: 'False',
        lookup: { True: 'True', False: 'False' } },
    { title: 'Accrual Method', field: 'accrualMethod', initialEditValue: 'Type' },
    { title: 'Exchange Type', field: 'exchangeType', initialEditValue: 'Type' },
    { title: 'Earning Per Share', field: 'earningsPerShareDiluted', type: 'numeric' },
    { title: 'Fund Family', field: 'fundFamilyId' },
    { title: 'Fund Category', field: 'fundFamilyId' },
    { title: 'Fund Number', field: 'fundNumber', initialEditValue: '0', type: 'numeric'},
    { title: 'Fund Status', field: 'fundStatusType', initialEditValue: 'Type' },
    { title: 'Short Term Redemption Fee %', field: 'shortTermRedemptionFeePercent', initialEditValue: 'Type', type: 'numeric' },
    { title: 'Short Term Holding Period', field: 'shortTermHoldingPeriod', initialEditValue: 'Type', type: 'numeric' },
    { title: 'Call Price', field: 'callPrice', initialEditValue: '0', type: 'numeric' },
    { title: 'Date of First Payment', field: 'dateOfIssue', type: 'date' },
];

export const stockColumns = [

    { title: 'Name', field: 'name', initialEditValue: 'name' },
    { title: 'Price', field: 'price', initialEditValue: '0', type: 'numeric' },
    { title: 'Quantity', field: 'quantity', initialEditValue: '1', type: 'numeric' },
    { title: 'Exchange Type', field: 'exchangeType', initialEditValue: 'Type' },
    { title: 'Earning Per Share', field: 'earningsPerShareDiluted', initialEditValue: '0', type: 'numeric' },
    { title: 'Earning Effective Date', field: 'earningsPerShareEffectiveDate', type: 'date' },
    { title: 'Payment Frequency Type', field: 'paymentFrequencyType', initialEditValue: 'Type' },
    { title: 'Shares Outstanding', field: 'sharesOutstanding', initialEditValue: '0', type: 'numeric' },
    {
        title: 'Is Included In 13F', field: 'isIncludedIn13F', initialEditValue: 'False',
        lookup: { True: 'True', False: 'False' }
    },
    {
        title: 'Is Restricted By 144A', field: 'isRestrictedByRule144A', initialEditValue: 'False',
        lookup: { True: 'True', False: 'False' }
    },
    { title: 'Calculated Market Cap Type', field: 'calculatedMarketCapType', initialEditValue: 'Type'  }
];

export const propertyColumns = [
    { title: 'Name', field: 'name', initialEditValue: 'name' },
    { title: 'Price', field: 'price', initialEditValue: '0', type: 'numeric' },
    { title: 'Quantity', field: 'quantity', initialEditValue: '1', type: 'numeric' },
    { title: 'Payment Frequency', field: 'paymentFrequencyType', initialEditValue: 'Type' },
    { title: 'Income Payment (Month)', field: 'incomePaymentMonth', initialEditValue: '0', type: 'numeric' },
    { title: 'Income Payment (Day)', field: 'incomePaymentDay', initialEditValue: '0', type: 'numeric' },
    { title: 'Parcel Number', field: 'realEstateParcelNumber', initialEditValue: '0', type: 'numeric' },
];

export const miscColumns = [
    { title: 'Name', field: 'name', initialEditValue: 'name' },
    { title: 'Price', field: 'price', initialEditValue: '0', type: 'numeric' },
    { title: 'Quantity', field: 'quantity', initialEditValue: '1', type: 'numeric' },
    { title: 'Payment Frequency', field: 'paymentFrequencyType', initialEditValue: 'Type' },
    { title: 'Income Payment (Month)', field: 'incomePaymentMonth', initialEditValue: '0', type: 'numeric' },
    { title: 'Income Payment (Day)', field: 'incomePaymentDay', initialEditValue: '0', type: 'numeric' },
    { title: 'Shares Outstanding', field: 'sharesOutstanding', initialEditValue: '0', type: 'numeric' },
    { title: 'Accrual Method', field: 'accrualFrequencyType', initialEditValue: 'Type' },
    { title: 'Compounding Frequency', field: 'compoundingFrequencyType', initialEditValue: 'Type' },
];

export const portfolioColumns = [
    { title: 'Asset ID', field: 'assetId'},
    { title: 'Asset Name', field: 'assetName' },
    { title: 'Asset Category', field: 'assetCategoryName'},
    { title: 'Total Value', field: 'totalValue' },
    { title: 'Total Amount', field: 'totalAmount'},
    { title: 'Price Per Share', field: 'pricePerShare'},
];

export const tradeColumns = [
    { title: 'Trade Type', field: 'tradeTypeName' },
    { title: 'Asset ID', field: 'assetId' },
    { title: 'Asset Name', field: 'assetName' },
    { title: 'Trade Option', field: 'tradeTypeName'},
    { title: 'Registration Type', field: 'registrationTypeName' },
    { title: 'Unit Shares', field: 'unitShares' }
];