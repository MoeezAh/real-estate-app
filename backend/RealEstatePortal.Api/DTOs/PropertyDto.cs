namespace RealEstatePortal.Api.DTOs
{
    public class PropertyDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Bedrooms { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<PropertyImageDto> Images { get; set; } = new List<PropertyImageDto>();
    }
}
