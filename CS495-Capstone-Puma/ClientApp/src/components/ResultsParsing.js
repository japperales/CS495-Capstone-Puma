
export function formatDoughnutChartValues(assets){
    let valueSumArray = sumDifferentAssetTypeValues(assets)

    const data = {
        labels: [
            'Money Markets',
            'Common Stock',
            'Mutual Funds',
            'Loans & Notes Receivables'
        ],
        datasets: [{
            data: valueSumArray,
            backgroundColor: [
                '#008080',
                '#1AE6E6',
                '#66FFFF',
                '#B2FFFF',
            ],
            hoverBackgroundColor: [
                '#FF6384',
                '#36A2EB',
                '#FFCE56',
                '#66ff00'
            ]
        }]
    };

    return data;
}

function sumDifferentAssetTypeValues(assets){
    let moneyMarketsValue = 0;
    let commonStockValue = 0;
    let mutualFundsValue = 0;
    let loansValue = 0;
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
            break;
        }
    });  
    console.log([moneyMarketsValue,commonStockValue,mutualFundsValue,loansValue]);
    return [moneyMarketsValue,commonStockValue,mutualFundsValue,loansValue];
    
}