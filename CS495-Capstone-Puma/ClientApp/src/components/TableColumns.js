
export const portfolioColumns = [
    { title: 'Asset Code', field: 'assetCode' },
    { title: 'Symbol', field: 'symbol' },
    { title: 'Issue', field: 'issue'},
    { title: 'Issuer', field: 'issuer' },
    { title: 'Units', field: 'units', type: 'numeric'},
    { title: 'Total Value', field: 'totalValue', type: 'numeric'},
];

export const revisedPortfolioColumns = [
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