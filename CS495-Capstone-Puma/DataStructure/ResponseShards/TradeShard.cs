namespace CS495_Capstone_Puma.DataStructure.ResponseShards
{
    public class TradeShard
    {
        public int AssetId { get; set; }
        
        public int TradeBlockId { get; set; }
        
        public string TradeTypeName { get; set; }
        
        public string TradeBasisOptionType { get; set; }

        public string RegistrationTypeName { get; set; }
        
        public float UnitShares { get; set; }

        public string AssetName { get; set; }
    }
    }
