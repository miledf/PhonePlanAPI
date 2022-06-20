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
    }
}