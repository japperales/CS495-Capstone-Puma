
export function formatDoughnutChartValues(assets){
    let valueSumArray = sumDifferentAssetTypeValues(assets)
//these are the currently supported types that the charts will recognize, with all other types being collected in 'other'
    const data = {
        labels: [
            'Money Markets',
            'Common Stock',
            'Mutual Funds',
            'Loans & Notes Receivables',
            'Other'
        ],
        datasets: [{
            data: valueSumArray,
            backgroundColor: [
                '#FF6384',
                '#36A2EB',
                '#FFCE56',
                '#66ff00',
                '#FFC0CB'
            ],
            hoverBackgroundColor: [
                '#FF6384',
                '#36A2EB',
                '#FFCE56',
                '#66ff00',
                '#FFC0CB'
            ]
        }]
    };

    return data;
}
//adds up all worth of asset types four doughnut chart display
export function sumDifferentAssetTypeValues(assets){
    let moneyMarketsValue = 0;
    let commonStockValue = 0;
    let mutualFundsValue = 0;
    let loansValue = 0;
    let otherValue = 0;
    assets.forEach((asset) => {
        switch (asset.assetCategoryName) {
            case "Money Markets":
                moneyMarketsValue += asset.totalValue;
                break;
            case "Common Stock":
                commonStockValue += asset.totalValue;
                break;
            case "Mutual Funds":
                mutualFundsValue += asset.totalValue;
                break;
            case "Loans & Notes Receivables":
                loansValue += asset.totalValue;
                break;
            default:
                otherValue += asset.totalValue;
            break;
        }
    });
    return [moneyMarketsValue,commonStockValue,mutualFundsValue,loansValue, otherValue];
    
}