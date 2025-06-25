using Microsoft.AspNetCore.Mvc;
using NoteApp.Models;
using NoteApp.Data;

namespace NoteApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public NoteController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateNote([FromBody] Note note)
        {
            _context.Notes.Add(note);
            _context.SaveChanges();
            return Ok("Not eklendi.");
        }

        [HttpGet]
        public IActionResult GetAllNotes()
        {
            var notes = _context.Notes.ToList();
            return Ok(notes);
        }

        [HttpGet("{id}")]
        public IActionResult GetNoteById(int id)
        {
            var note = _context.Notes.FirstOrDefault(n => n.Id == id);
            if (note == null)
                return NotFound("Not bulunamadı.");
            return Ok(note);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateNote(int id, [FromBody] Note updatedNote)
        {
            var note = _context.Notes.FirstOrDefault(n => n.Id == id);
            if (note == null)
                return NotFound("Not bulunamadı.");

            note.Title = updatedNote.Title;
            note.Content = updatedNote.Content;

            _context.SaveChanges();
            return Ok("Not güncellendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNote(int id)
        {
            var note = _context.Notes.FirstOrDefault(n => n.Id == id);
            if (note == null)
                return NotFound("Not bulunamadı.");

            _context.Notes.Remove(note);
            _context.SaveChanges();
            return Ok("Not silindi.");
        }
    }
}
