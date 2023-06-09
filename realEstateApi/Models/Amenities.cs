namespace realEstateApi.Models
{
    public class Amenities
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required List<Property> Properties { get; set; }
    }
}
