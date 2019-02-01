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
    public class MessageDetailsController2 : ControllerBase
    {
        private readonly UserDetailContext _context;

        public MessageDetailsController2(UserDetailContext context)
        {
            _context = context;
        }

        // GET: api/MessageDetailsController2
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MessageDetail>>> GetMessageDetail()
        {
            return await _context.MessageDetail.ToListAsync();
        }

        // GET: api/MessageDetailsController2/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MessageDetail>> GetMessageDetail(int id)
        {
            var messageDetail = await _context.MessageDetail.FindAsync(id);

            if (messageDetail == null)
            {
                return NotFound();
            }

            return messageDetail;
        }

        // PUT: api/MessageDetailsController2/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMessageDetail(int id, MessageDetail messageDetail)
        {
            if (id != messageDetail.MessageID)
            {
                return BadRequest();
            }

            _context.Entry(messageDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessageDetailExists(id))
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

        // POST: api/MessageDetailsController2
        [HttpPost]
        public async Task<ActionResult<MessageDetail>> PostMessageDetail(MessageDetail messageDetail)
        {
            _context.MessageDetail.Add(messageDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMessageDetail", new { id = messageDetail.MessageID }, messageDetail);
        }

        // DELETE: api/MessageDetailsController2/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MessageDetail>> DeleteMessageDetail(int id)
        {
            var messageDetail = await _context.MessageDetail.FindAsync(id);
            if (messageDetail == null)
            {
                return NotFound();
            }

            _context.MessageDetail.Remove(messageDetail);
            await _context.SaveChangesAsync();

            return messageDetail;
        }

        private bool MessageDetailExists(int id)
        {
            return _context.MessageDetail.Any(e => e.MessageID == id);
        }
    }
}
