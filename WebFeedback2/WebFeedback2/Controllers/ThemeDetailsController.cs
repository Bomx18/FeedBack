using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebFeedback2.Models;

namespace WebFeedback2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThemeDetailsController : ControllerBase
    {
        private readonly UserDetailContext _context;

        public ThemeDetailsController(UserDetailContext context)
        {
            _context = context;
        }

        // GET: api/ThemeDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ThemeDetail>>> GetThemeDetail()
        {
            return await _context.ThemeDetail.ToListAsync();
        }

        // GET: api/ThemeDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ThemeDetail>> GetThemeDetail(int id)
        {
            var themeDetail = await _context.ThemeDetail.FindAsync(id);

            if (themeDetail == null)
            {
                return NotFound();
            }

            return themeDetail;
        }

        // PUT: api/ThemeDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutThemeDetail(int id, ThemeDetail themeDetail)
        {
            if (id != themeDetail.ThemeID)
            {
                return BadRequest();
            }

            _context.Entry(themeDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThemeDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ThemeDetails
        [HttpPost]
        public async Task<ActionResult<ThemeDetail>> PostThemeDetail(ThemeDetail themeDetail)
        {
            _context.ThemeDetail.Add(themeDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetThemeDetail", new { id = themeDetail.ThemeID }, themeDetail);
        }

        // DELETE: api/ThemeDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ThemeDetail>> DeleteThemeDetail(int id)
        {
            var themeDetail = await _context.ThemeDetail.FindAsync(id);
            if (themeDetail == null)
            {
                return NotFound();
            }

            _context.ThemeDetail.Remove(themeDetail);
            await _context.SaveChangesAsync();

            return themeDetail;
        }

        private bool ThemeDetailExists(int id)
        {
            return _context.ThemeDetail.Any(e => e.ThemeID == id);
        }
    }
}
