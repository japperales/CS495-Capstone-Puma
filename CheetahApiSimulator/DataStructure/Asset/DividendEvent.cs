using System;
using Newtonsoft.Json;

namespace CheetahApiSimulator.DataStructure.Asset
{
    public class DividendEvent
    {
        [JsonProperty("DividendPaymentType")]
        public string DividendPaymentType { get; set; }

        [JsonProperty("DividendPaymentTypeName")]
        public string DividendPaymentTypeName { get; set; }

        [JsonProperty("DividendAmountPerShare")]
        public long DividendAmountPerShare { get; set; }

        [JsonProperty("DividendStockPerShare")]
        public long DividendStockPerShare { get; set; }

        [JsonProperty("DividendSplitRatio")]
        public string DividendSplitRatio { get; set; }

        [JsonProperty("IndicatedAnnualDividendPerShare")]
        public long IndicatedAnnualDividendPerShare { get; set; }

        [JsonProperty("DateExDividend")]
        public DateTimeOffset DateExDividend { get; set; }

        [JsonProperty("DateOfRecord")]
        public DateTimeOffset DateOfRecord { get; set; }

        [JsonProperty("DateOfPayment")]
        public DateTimeOffset DateOfPayment { get; set; }

        [JsonProperty("DateAnnounced")]
        public DateTimeOffset DateAnnounced { get; set; }

        [JsonProperty("EventCode")]
        public string EventCode { get; set; }

        [JsonProperty("EventRevisionCode")]
        public string EventRevisionCode { get; set; }

        [JsonProperty("IsActive")]
        public bool IsActive { get; set; }

        [JsonProperty("CreatedDate")]
        public DateTimeOffset CreatedDate { get; set; }

        [JsonProperty("ModifiedDate")]
        public DateTimeOffset ModifiedDate { get; set; }

        [JsonProperty("ModifiedBy")]
        public string ModifiedBy { get; set; }

        [JsonConstructor]
        public DividendEvent(string dividendPaymentType, string dividendPaymentTypeName, long dividendAmountPerShare, long dividendStockPerShare, string dividendSplitRatio, long indicatedAnnualDividendPerShare, DateTimeOffset dateExDividend, DateTimeOffset dateOfRecord, DateTimeOffset dateOfPayment, DateTimeOffset dateAnnounced, string eventCode, string eventRevisionCode, bool isActive, DateTimeOffset createdDate, DateTimeOffset modifiedDate, string modifiedBy)
        {
            DividendPaymentType = dividendPaymentType;
            DividendPaymentTypeName = dividendPaymentTypeName;
            DividendAmountPerShare = dividendAmountPerShare;
            DividendStockPerShare = dividendStockPerShare;
            DividendSplitRatio = dividendSplitRatio;
            IndicatedAnnualDividendPerShare = indicatedAnnualDividendPerShare;
            DateExDividend = dateExDividend;
            DateOfRecord = dateOfRecord;
            DateOfPayment = dateOfPayment;
            DateAnnounced = dateAnnounced;
            EventCode = eventCode;
            EventRevisionCode = eventRevisionCode;
            IsActive = isActive;
            CreatedDate = createdDate;
            ModifiedDate = modifiedDate;
            ModifiedBy = modifiedBy;
        }
    }
}