using System.Collections.Generic;
using Newtonsoft.Json;

namespace CS495_Capstone_Puma.DataStructure.JsonResponse
{
    public class TradeResponse
    {
        private List<Trade> trades { get; set; }
        
        public TradeResponse()
        {
            trades = new List<Trade>();
        }

        [JsonConstructor]
        public TradeResponse(List<Trade> trades)
        {
            this.trades = trades;
        }
    }
}