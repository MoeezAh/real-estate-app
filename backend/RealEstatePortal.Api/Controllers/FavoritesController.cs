using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstatePortal.Infrastructure;
using RealEstatePortal.Domain.Models;

namespace RealEstatePortal.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoritesController : ControllerBase
    {
        private readonly RealEstateDbContext _context;
        public FavoritesController(RealEstateDbContext context)
        {
            _context = context;
        }

        // Extract userId from JWT token
        private int GetUserId()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "userId");
            return userIdClaim != null ? int.Parse(userIdClaim.Value) : 0;
        }

        [HttpGet]
        [Microsoft.AspNetCore.Authorization.Authorize]
        public async Task<ActionResult<IEnumerable<Property>>> GetFavorites()
        {
            var userId = GetUserId();
            if (userId == 0) return Unauthorized();
            var favoriteIds = await _context.Favorites.Where(f => f.UserId == userId).Select(f => f.PropertyId).ToListAsync();
            var properties = await _context.Properties.Where(p => favoriteIds.Contains(p.Id)).ToListAsync();
            return properties;
        }

        [HttpPost("{propertyId}")]
        [Microsoft.AspNetCore.Authorization.Authorize]
        public async Task<IActionResult> AddFavorite(int propertyId)
        {
            var userId = GetUserId();
            if (userId == 0) return Unauthorized();
            if (!_context.Favorites.Any(f => f.UserId == userId && f.PropertyId == propertyId))
            {
                _context.Favorites.Add(new Favorite { UserId = userId, PropertyId = propertyId });
                await _context.SaveChangesAsync();
            }
            return Ok();
        }

        [HttpDelete("{propertyId}")]
        [Microsoft.AspNetCore.Authorization.Authorize]
        public async Task<IActionResult> RemoveFavorite(int propertyId)
        {
            var userId = GetUserId();
            if (userId == 0) return Unauthorized();
            var favorite = await _context.Favorites.FirstOrDefaultAsync(f => f.UserId == userId && f.PropertyId == propertyId);
            if (favorite != null)
            {
                _context.Favorites.Remove(favorite);
                await _context.SaveChangesAsync();
            }
            return Ok();
        }
    }
}
