using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebFeedback2.Models;

namespace WebFeedback2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailController : ControllerBase
    {
        private readonly UserDetailContext _context;
        

        public UserDetailController(UserDetailContext context)
        {
            _context = context;
        }

        // GET: api/UserDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDetail>>> GetUserDetail()
        {
            return await _context.UserDetail.ToListAsync();
        }
        


        // GET: api/UserDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDetail>> GetUserDetail(int id)
        {
            var userDetail = await _context.UserDetail.FindAsync(id);

            if (userDetail == null)
            {
                return NotFound();
            }

            return userDetail;
        }

        // PUT: api/UserDetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserDetail(int id, UserDetail userDetail)
        {
            if (id != userDetail.UserID)
            {
                return BadRequest();
            }

            _context.Entry(userDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserDetailExists(id))
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

        // POST: api/UserDetail
        [HttpPost]
        public async Task<ActionResult<UserDetail>> PostUserDetail(UserDetail userDetail)
        {
            if (ModelState.IsValid)
            {  
                UserDetail userphone = await _context.UserDetail.FirstOrDefaultAsync(u => u.UserNumPhone == userDetail.UserNumPhone);
                UserDetail useremail = await _context.UserDetail.FirstOrDefaultAsync(u => u.UserEmail == userDetail.UserEmail);
                if (userphone == null && useremail == null )
                {
                    _context.UserDetail.Add(userDetail);
                    
                    await _context.SaveChangesAsync();
                    return CreatedAtAction("GetUserDetail", new { id = userDetail.UserID }, userDetail);
                } 
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return NotFound();
        }






        // DELETE: api/UserDetail/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserDetail>> DeleteUserDetail(int id)
        {
            var userDetail = await _context.UserDetail.FindAsync(id);
            if (userDetail == null)
            {
                return NotFound();
            }

            _context.UserDetail.Remove(userDetail);
            await _context.SaveChangesAsync();

            return userDetail;
        }

        private bool UserDetailExists(int id)
        {
            return _context.UserDetail.Any(e => e.UserID == id);
        }
    }
}
