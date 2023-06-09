namespace realEstateApi.Models
{
    public class Agent
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required List<Property> Properties { get; set; }
    }
}