namespace PhonePlanAPI.Models
{
    public class PhonePlan
    {
        public int Id { get; set; }
        public int Minutes { get; set; }
        public int Internet { get; set; }
        public decimal Value { get; set; }

        public int IdPlanType { get; set; }
        public int IdOperator { get; set; }

        public PlanType? PlanType { get; set; }

        public Operator? Operator { get; set; }

        public List<PlanDDD>? DDDs { get; set; }

        public PhonePlanDTO MapToPhonePlanDTO()
        {
            return new PhonePlanDTO
            {
                Id = Id,
                IdPlanType = IdPlanType,
                IdOperator = IdOperator,
                Value = Value,
                Internet = Internet,
                Minutes = Minutes,
                DDDs = DDDs?.Select(x => x.IdDDD).ToList()
            };
        }
    }
}