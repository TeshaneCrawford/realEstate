

namespace realEstateApi.Models
{
    public class Property
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        //public decimal Price { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public required string Location { get; set; }
        public bool IsAvailable { get; set; }
        public int AgentId { get; set; }
        public required Agent Agent { get; set; }
        public required List<Image> Images { get; set; }
        public required List<Amenities> Amenities { get; set; }
        public required List<Inquiry> Inquiries { get; set; }
        public required Price Price { get; set; }
    }
}
