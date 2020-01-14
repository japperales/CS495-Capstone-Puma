using System;

namespace CS495_Capstone_Puma.DataStructure.JsonRequest
{
    public class TransactionRequest
    {
        public int accountId { get; set; }
        
        public DateTime dateTraded { get; }
        
        public DateTime dateSettled { get; }

        public int transactionBatchId { get; set; }

        public int transactionCategoryId { get; }

        public int locationTypeId { get; set; }

        public int registrationTypeId { get; set; }

        public int assetId { get; set; }

        public int units { get; set; }

        public TransactionRequest(int accountId, int transactionBatchId, int locationTypeId, int registrationTypeId,
            int assetId, int units)
        {
            this.accountId = accountId;
            dateTraded = DateTime.Now;
            dateSettled = DateTime.Now;
            this.transactionBatchId = transactionBatchId;
            transactionCategoryId = 6750;
            this.locationTypeId = locationTypeId;
            this.registrationTypeId = registrationTypeId;
            this.assetId = assetId;
            this.units = units;
        }
    }
}