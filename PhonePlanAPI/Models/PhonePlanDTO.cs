namespace PhonePlanAPI.Models
{
    public class PhonePlanDTO
    {
        public int Id { get; set; }

        public int Minutes { get; set; }

        public int Internet { get; set; }

        public decimal Value { get; set; }

        public int IdPlanType { get; set; }

        public int IdOperator { get; set; }

        public List<int>? DDDs { get; set; }

        public PhonePlan MapToPhonePlan()
        {
            return new PhonePlan
            {
                Id = Id,
                Internet = Internet,
                Minutes = Minutes,
                Value = Value,
                IdOperator = IdOperator,
                IdPlanType = IdPlanType,
                DDDs = DDDs?.Select(x => new PlanDDD { IdDDD = x, IdPhonePlan = Id }).ToList()
            };
        }
    }
}