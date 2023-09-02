namespace Note.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Note.Data.Models; // Replace with the appropriate namespace for your models and services.

    [ApiController]
    [Route("api/notes")]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet]
        public IActionResult GetAllNotes()
        {
            var notes = _noteService.GetAll();
            return Ok(notes);
        }

        [HttpGet("{id}")]
        public IActionResult GetNoteById(int id)
        {
            var note = _noteService.Get(id);
            if (note == null)
            {
                return NotFound();
            }
            return Ok(note);
        }

        [HttpPost]
        public IActionResult CreateNote([FromBody] Entry newNote)
        {
            var createdNote = _noteService.Create(newNote);
            return CreatedAtAction(nameof(GetNoteById), new { id = createdNote.Id }, createdNote);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateNote(int id, [FromBody] Entry updatedNote)
        {
            var success = _noteService.Update(id, updatedNote);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNote(int id)
        {
            var success = _noteService.Delete(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }

}
