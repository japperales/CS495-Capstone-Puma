using System.Collections.Generic;
using System.Linq;
using CS495_Capstone_Puma.DataStructure.JsonResponse.Asset;
using CS495_Capstone_Puma.Model;

namespace CS495_Capstone_Puma.AutoFill
{
    public static class AssetMatcher
    {
        private static List<AssetLookupResponse> _allAssets = new List<AssetLookupResponse>();
        
        public static void UpdateAssets(string bearerToken)
        {
            _allAssets = CheetahHandler.GetFullAssetList(bearerToken);
        }

        public static List<AssetLookupResponse> GetMatches(string value)
        {
            List<AssetLookupResponse> matches = new List<AssetLookupResponse>();
            value = value.ToLower();
            foreach (AssetLookupResponse asset in _allAssets)
            {
                if (asset.value.symbol.ToLower().StartsWith(value) || asset.value.issuer.ToLower().StartsWith(value))
                {
                    matches.Add(asset);
                    if (matches.Count == 5)
                    {
                        return matches;
                    }
                }
            }

            return matches;
        }

        public static List<AssetLookupResponse> GetAllAssets()
        {
            return _allAssets;
        }
    }
}