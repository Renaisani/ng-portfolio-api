using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestNETCoreApp_API.Data;

namespace TestNETCoreApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly DataContext _context;
        public BlogController(DataContext context) 
        {
            _context = context;
        }
        [HttpGet]

        public async Task<ActionResult<List<Blog>>> GetBlogEntries()
        {
            return Ok(await _context.Blog.ToListAsync());
            
        }

        [HttpPost]

        public async Task<ActionResult<List<Blog>>> CreateBlogEntry(Blog blogEntry)
        {
            _context.Blog.Add(blogEntry);
            await _context.SaveChangesAsync();

            return Ok(await _context.Blog.ToListAsync());
        }

        [HttpPut]

        public async Task<ActionResult<List<Blog>>> UpdateBlogEntry(Blog blogEntry)
        {
            var dbBlogEntry = await _context.Blog.FindAsync(blogEntry.Id);
            if (dbBlogEntry == null)
                return BadRequest("Blog entry not found.");

            dbBlogEntry.Name = blogEntry.Name;
            dbBlogEntry.Content = blogEntry.Content;

            await _context.SaveChangesAsync();

            return Ok(await _context.Blog.ToListAsync());
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<List<Blog>>> DeleteBlogEntry(int id)
        {
            var dbBlogEntry = await _context.Blog.FindAsync(id);
            if (dbBlogEntry == null)
                return BadRequest("Blog entry not found.");

            _context.Blog.Remove(dbBlogEntry);
            await _context.SaveChangesAsync();

            return Ok(await _context.Blog.ToListAsync());
        }
    }
}
