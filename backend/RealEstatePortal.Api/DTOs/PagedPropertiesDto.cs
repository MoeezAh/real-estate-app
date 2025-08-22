namespace RealEstatePortal.Api.DTOs
{
    public class PagedPropertiesDto
    {
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public List<PropertyDto> Properties { get; set; } = new List<PropertyDto>();
    }
}
