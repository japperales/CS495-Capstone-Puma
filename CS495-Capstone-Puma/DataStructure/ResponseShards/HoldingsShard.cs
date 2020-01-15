using System;
using System.Collections;
using System.Collections.Generic;


namespace CS495_Capstone_Puma.DataStructure.ResponseShards
{
    public class HoldingsShard
    {
        public int AssetId { get; set; }
        
        public string AssetName { get; set; }

        public string AssetCategoryName { get; set; }

        public float TotalValue { get; set; }
        
        public float TotalAmount { get; set; }
        
        public float PricePerShare { get; set; }
        

        public void CalculateFieldsFromLots(IList<LotShard> lotShards)
        {
            CalculateAssetAmount(lotShards);
            CalculatePricePerShareFromLot(lotShards);
            CalculateTotalValueFromLots(lotShards);
        }

        private void CalculateTotalValueFromLots(IList<LotShard> lotShards)
        {
            TotalValue = lotShards[0].MarketValueActual;
        }
    
        private void CalculateAssetAmount(IList<LotShard> lotShards)
        {
            float assetAmountSum = 0;
            foreach (LotShard lotShard in lotShards)
            {
                assetAmountSum = assetAmountSum + lotShard.UnitsActual;
            }

            TotalAmount = assetAmountSum;
        }

        private void CalculatePricePerShareFromLot(IList<LotShard> lotShards)
        {
            PricePerShare = lotShards[0].AssetPrice;
        }
        
    }
}