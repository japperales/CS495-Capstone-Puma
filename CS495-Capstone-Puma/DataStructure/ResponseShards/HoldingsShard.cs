using System.Collections.Generic;

namespace CS495_Capstone_Puma.DataStructure.ResponseShards
{
    public class HoldingsShard
    {
        public int AssetId;

        public string AssetCategoryName;

        public List<LotShard> LotList;

    }
}