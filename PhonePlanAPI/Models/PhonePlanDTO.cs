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
    }
}