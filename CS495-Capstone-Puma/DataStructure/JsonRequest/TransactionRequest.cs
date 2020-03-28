using System;

namespace CS495_Capstone_Puma.DataStructure.JsonRequest
{
    public class TransactionRequest
    {
        public int AccountId { get; set; }

        private DateTime DateTraded { get; }

        private DateTime DateSettled { get; }

        private int TransactionBatchId { get; set; }

        private int TransactionCategoryId { get; }

        private int LocationTypeId { get; set; }

        private int RegistrationTypeId { get; set; }

        public int AssetId { get; set; }

        private int Units { get; set; }

        public TransactionRequest(int accountId, int transactionBatchId, int locationTypeId, int registrationTypeId,
            int assetId, int units)
        {
            AccountId = accountId;
            DateTraded = DateTime.Now;
            DateSettled = DateTime.Now;
            TransactionBatchId = transactionBatchId;
            TransactionCategoryId = 6750;
            LocationTypeId = locationTypeId;
            RegistrationTypeId = registrationTypeId;
            AssetId = assetId;
            Units = units;
        }
    }
}