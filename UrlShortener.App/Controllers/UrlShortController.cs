using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UrlShortener.App.Data;
using UrlShortener.App.Models;

namespace UrlShortener.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlShortController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UrlShortController(AppDbContext context)
        {
            _context = context;
        }
        
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string longUrl)
        {
            var existingUrl = await _context.OriginalUrls.FirstOrDefaultAsync(u => u.LongUrl == longUrl);
            if (existingUrl != null)
            {
                return Ok(existingUrl.ShortCode);
            }

            var shortCode = GenerateShortCode();

            var newUrl = new OriginalUrl
            {
                LongUrl = longUrl,
                ShortCode = shortCode
            };

            _context.OriginalUrls.Add(newUrl);
            await _context.SaveChangesAsync();
            
            return Ok(shortCode);
        }
        
        private string GenerateShortCode()
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, 15)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
