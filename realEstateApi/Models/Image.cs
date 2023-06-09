namespace realEstateApi.Models
{
    public class Image
    {
        public int Id { get; set; }
        public required string Url { get; set; }
        public int PropertyId { get; set; }
        public required Property Property { get; set; }
    }
}
