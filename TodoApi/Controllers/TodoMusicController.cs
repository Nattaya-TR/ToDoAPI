using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using TodoApi.Models.Data;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoMusicController : ControllerBase
    {
        private readonly TodoMusicContext _context;

        public TodoMusicController(TodoMusicContext context)
        {
            _context = context;
        }

        // GET: api/TodoMusic
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoMusic>>> GetTodoMusics()
        {
            return await _context.TodoMusics.ToListAsync();
        }

        // GET: api/TodoMusic/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoMusic>> GetTodoMusic(long id)
        {
            var todoMusic = await _context.TodoMusics.FindAsync(id);

            if (todoMusic == null)
            {
                return NotFound();
            }

            return todoMusic;
        }

        // PUT: api/TodoMusic/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoMusic(long id, TodoMusic todoMusic)
        {
            if (id != todoMusic.Id)
            {
                return BadRequest();
            }

            _context.Entry(todoMusic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoMusicExists(id))
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

        // POST: api/TodoMusic
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TodoMusic>> PostTodoMusic(TodoMusic todoMusic)
        {
            _context.TodoMusics.Add(todoMusic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodoMusic", new { id = todoMusic.Id }, todoMusic);
        }

        // DELETE: api/TodoMusic/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoMusic(long id)
        {
            var todoMusic = await _context.TodoMusics.FindAsync(id);
            if (todoMusic == null)
            {
                return NotFound();
            }

            _context.TodoMusics.Remove(todoMusic);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TodoMusicExists(long id)
        {
            return _context.TodoMusics.Any(e => e.Id == id);
        }
    }
}
