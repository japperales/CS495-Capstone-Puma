using Newtonsoft.Json;

namespace CheetahApiSimulator.DataStructure.Asset.AssetCategory
{
    public class Property
    {
        [JsonProperty("IncomePaymentFrequencyType")]
        public string IncomePaymentFrequencyType { get; set; }

        [JsonProperty("IncomePaymentFrequencyTypeName")]
        public string IncomePaymentFrequencyTypeName { get; set; }

        [JsonProperty("IncomePaymentMonth")]
        public long? IncomePaymentMonth { get; set; }

        [JsonProperty("IncomePaymentDay")]
        public long? IncomePaymentDay { get; set; }

        [JsonProperty("RealEstateParcelNumber")]
        public string RealEstateParcelNumber { get; set; }

        [JsonProperty("InsurancePolicyNumber")]
        public string InsurancePolicyNumber { get; set; }

        public Property()
        {
            IncomePaymentFrequencyType = null;
            IncomePaymentFrequencyTypeName = null;
            IncomePaymentMonth = null;
            IncomePaymentDay = null;
            RealEstateParcelNumber = null;
            InsurancePolicyNumber = null;
        }
        [JsonConstructor]
        public Property(string incomePaymentFrequencyType, string incomePaymentFrequencyTypeName, long incomePaymentMonth, long incomePaymentDay, string realEstateParcelNumber, string insurancePolicyNumber)
        {
            IncomePaymentFrequencyType = incomePaymentFrequencyType;
            IncomePaymentFrequencyTypeName = incomePaymentFrequencyTypeName;
            IncomePaymentMonth = incomePaymentMonth;
            IncomePaymentDay = incomePaymentDay;
            RealEstateParcelNumber = realEstateParcelNumber;
            InsurancePolicyNumber = insurancePolicyNumber;
        }
    }
}