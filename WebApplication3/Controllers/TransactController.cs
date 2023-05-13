using ASPNetCoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;
using Microsoft.AspNetCore.Cors;
using System.Runtime.CompilerServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication3.Controllers
{
    [Route("api/transact")]
    [EnableCors]
    [ApiController]
    public class TransactController : ControllerBase
    {
        private readonly Context _context;

        public TransactController(Context context)
        {
            _context = context;
        }

        // GET: api/<TransactController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transact>>> GetTransact()
        {
            return await _context.Transact.Include(t => t.Category).ToListAsync();
        }

        // GET api/<TransactController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transact>> GetTransact(int id)
        {
            var transact = await _context.Transact.FindAsync(id);

            if (transact == null)
            {
                return NotFound();
            }

            return transact;
        }

        // POST api/<TransactController>
        [HttpPost]
        public async Task<ActionResult<Transact>> PostTransact(TransactDTO transactDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Transact transact = new Transact
            {
                Type = transactDTO.Type,
                Date = transactDTO.Date,
                Sum = transactDTO.Sum,
                CategoryId = transactDTO.CategoryId,
                UserId = transactDTO.UserId,
                User = _context.User.Find(transactDTO.UserId),
                Category = _context.Category.Find(transactDTO.CategoryId)
            };

            _context.Transact.Add(transact);
            _context.User.Find(transact.UserId).Balance += transact.Sum * transact.Type;
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransact", new { id = transact.Id }, transact);
        }

        // PUT api/<TransactController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransact([FromRoute] int id, [FromBody] TransactDTO transactDTO)
        {
            var transact = _context.Transact.Find(id);

            if (transact == null)
            {
                return NotFound();
            }

            transact.Type = transactDTO.Type;
            transact.Date = transactDTO.Date;
            transact.Sum = transactDTO.Sum;
            transact.CategoryId = transactDTO.CategoryId;
            transact.UserId = transactDTO.UserId;
            transact.User = _context.User.Find(transactDTO.UserId);
            transact.Category = _context.Category.Find(transactDTO.CategoryId);

            _context.Transact.Update(transact);
            await _context.SaveChangesAsync();
            return Ok(transact);
        }

        // DELETE api/<TransactController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransact(int id)
        {
            var transact = await _context.Transact.FindAsync(id);
            if (transact == null)
            {
                return NotFound();
            }

            _context.Transact.Remove(transact);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// функция проверки существования транзакции
        /// </summary>
        /// <returns></returns>
        private bool TransactExists(int id)
        {
            return _context.Transact.Any(e => e.Id == id);
        }
    }
}
