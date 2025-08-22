namespace RealEstatePortal.Domain.Models
{
    public class PropertyImage
    {
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public int PropertyId { get; set; }
        public Property? Property { get; set; }
    }
}
