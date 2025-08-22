namespace RealEstatePortal.Domain.Models
{
    public class Property
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public decimal Price { get; set; }
        public string? ListingType { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public int CarSpots { get; set; }
        public string? Description { get; set; }
        public List<PropertyImage> Images { get; set; } = new();
    }
}
