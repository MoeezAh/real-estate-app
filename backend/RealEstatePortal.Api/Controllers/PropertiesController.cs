using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstatePortal.Infrastructure;
using RealEstatePortal.Domain.Models;
using RealEstatePortal.Api.DTOs;



namespace RealEstatePortal.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PropertiesController : ControllerBase
    {
        private readonly RealEstateDbContext _context;
        public PropertiesController(RealEstateDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PropertyDto>>> GetProperties([FromQuery] string? ids)
        {
            IQueryable<Property> query = _context.Properties.Include(p => p.Images);
            if (!string.IsNullOrEmpty(ids))
            {
                var idList = ids.Split(',').Select(int.Parse).ToList();
                query = query.Where(p => idList.Contains(p.Id));
            }

            // Filters
            var city = Request.Query["city"].ToString();
            var minPriceStr = Request.Query["minPrice"].ToString();
            var maxPriceStr = Request.Query["maxPrice"].ToString();
            var bedroomsStr = Request.Query["bedrooms"].ToString();

            if (!string.IsNullOrWhiteSpace(city))
                query = query.Where(p => (p.City ?? string.Empty).ToLower().Contains(city.ToLower()));
            if (decimal.TryParse(minPriceStr, out var minPrice))
                query = query.Where(p => p.Price >= minPrice);
            if (decimal.TryParse(maxPriceStr, out var maxPrice))
                query = query.Where(p => p.Price <= maxPrice);
            if (int.TryParse(bedroomsStr, out var bedrooms))
                query = query.Where(p => p.Bedrooms == bedrooms);

            // Paging
            int page = 1;
            int pageSize = 12;
            if (Request.Query.ContainsKey("page")) int.TryParse(Request.Query["page"], out page);
            if (Request.Query.ContainsKey("pageSize")) int.TryParse(Request.Query["pageSize"], out pageSize);
            if (page < 1) page = 1;
            if (pageSize < 1) pageSize = 12;

            int totalCount = await query.CountAsync();
            var properties = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            var dtos = properties.Select(p => new PropertyDto
            {
                Id = p.Id,
                Title = p.Title ?? string.Empty,
                City = p.City ?? string.Empty,
                Price = p.Price,
                Bedrooms = p.Bedrooms,
                Description = p.Description ?? string.Empty,
                Images = p.Images?.Select(img => new PropertyImageDto { Id = img.Id, Url = img.Url ?? string.Empty }).ToList() ?? new List<PropertyImageDto>()
            }).ToList();

            var result = new PagedPropertiesDto
            {
                TotalCount = totalCount,
                Page = page,
                PageSize = pageSize,
                Properties = dtos
            };
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PropertyDto>> GetProperty(int id)
        {
            var property = await _context.Properties.Include(p => p.Images).FirstOrDefaultAsync(p => p.Id == id);
            if (property == null) return NotFound();
            var dto = new PropertyDto
            {
                Id = property.Id,
                Title = property.Title ?? string.Empty,
                City = property.City ?? string.Empty,
                Price = property.Price,
                Bedrooms = property.Bedrooms,
                Description = property.Description ?? string.Empty,
                Images = property.Images?.Select(img => new PropertyImageDto { Id = img.Id, Url = img.Url ?? string.Empty }).ToList() ?? new List<PropertyImageDto>()
            };
            return Ok(dto);
        }
    }
}
