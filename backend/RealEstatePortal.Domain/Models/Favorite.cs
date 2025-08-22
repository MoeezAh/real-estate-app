namespace RealEstatePortal.Domain.Models
{
    public class Favorite
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PropertyId { get; set; }
    }
}
