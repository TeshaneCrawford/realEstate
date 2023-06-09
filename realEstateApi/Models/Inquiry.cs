namespace realEstateApi.Models
{
    public class Inquiry
    {
        public int Id { get; set; }
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string Message { get; set; }
        public int PropertyId { get; set; }
        public required Property Property { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
