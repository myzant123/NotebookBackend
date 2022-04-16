using Application.DTO;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Notebook.Controllers;

[ApiController]
[Route("[controller]")]
public class NoteController : ControllerBase
{
    private readonly INoteService _noteService;
    
    public NoteController(INoteService noteService)
    {
        _noteService = noteService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var notes = _noteService.GetAllNotes();
        return Ok(notes);
    }
    
    [HttpGet("{keyword}")]
    public IActionResult Search(string keyword)
    {
        var notes = _noteService.SearchByKeyword(keyword);
        return Ok(notes);
    }

    [HttpGet("{id:long}")]
    public IActionResult Get(long id)
    {
        var note = _noteService.GetNoteById(id);
        if(note == null) return NotFound();
        return Ok(note);
    }

    [HttpPost]
    public IActionResult Create(NoteDtoCreate newNote)
    {
        var note = _noteService.AddNewNote(newNote);
        return Created($"notes/{note.Id}", note);
    }

    [HttpPut("{id}")]
    public IActionResult Update(long id, NoteDtoUpdate updateNote)
    {
        _noteService.UpdateNote(id, updateNote);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        _noteService.DeleteNote(id);
        return NoContent();
    }
}