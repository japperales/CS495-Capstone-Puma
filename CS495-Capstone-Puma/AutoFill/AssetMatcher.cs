using System;
using System.Collections.Generic;
using System.Linq;
using CS495_Capstone_Puma.DataStructure;
using CS495_Capstone_Puma.DataStructure.JsonResponse.Asset;
using CS495_Capstone_Puma.DataStructure.ResponseShards;
using CS495_Capstone_Puma.Model;


namespace CS495_Capstone_Puma.AutoFill
{
    public static class AssetMatcher
    {
        private static List<AssetLookupResponse> _allAssets = new List<AssetLookupResponse>();
        private static readonly CheetahConfig CheetahConfig = CheetahHandler.LoadApiConfig();
        
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
        
        public static AssetLookupResponse GetValidatedAsset(AssetValidationForm assetLookup, string bearerToken)
        { 

            foreach (AssetLookupResponse asset in _allAssets)
            {
                if (asset.value.symbol != null && assetLookup.value.symbol != null)
                {
                    if (asset.value.symbol.ToLower().Equals(assetLookup.value.symbol.ToLower()))
                    {
                        AssetLookupResponse pricedAsset = GetAssetPricePerShare(asset, bearerToken);
                        return pricedAsset;
                    }
                }

                if (asset.value.issuer != null && assetLookup.value.issuer != null)
                {
                    if (asset.value.issuer.ToLower().Equals(assetLookup.value.issuer.ToLower()))
                    {
                        AssetLookupResponse pricedAsset = GetAssetPricePerShare(asset, bearerToken);
                        return pricedAsset;
                    }
                }
            }

            return null;
        }

        private static AssetLookupResponse GetAssetPricePerShare(AssetLookupResponse asset, string bearerToken)
        {
            AssetShard shard = ProposalGet.GetAssetFromId(CheetahConfig, Int32.Parse(asset.id), bearerToken).Result;
            asset.pricePerShare = shard.Price;
            asset.AssetCategory = shard.AssetCategoryDisplayName;
            Console.WriteLine("Asset Category Name is: " + shard.AssetCategoryDisplayName);
            Console.WriteLine("Asset price per share equals: " + asset.pricePerShare);
            return asset;
        }
        
       /* private static AssetLookupResponse GetAssetCategory(AssetLookupResponse asset, string bearerToken)
        {
            AssetShard shard = ProposalGet.GetAssetFromId(CheetahConfig, Int32.Parse(asset.id), bearerToken).Result;
            asset.pricePerShare = shard.Price;
            Console.WriteLine("Asset price per share equals: " + asset.pricePerShare);
            return asset;
        }*/
    }
}