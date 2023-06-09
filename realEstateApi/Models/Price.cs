namespace realEstateApi.Models
{
    public class Price
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public required string Currency { get; set; }
        public int PropertyId { get; set; }
        public required Property Property { get; set; }
    }
}
