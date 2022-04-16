using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.Interfaces;

namespace Application.Services;

public class NoteService : INoteService
{
    private readonly INoteRepository _noteRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    
    public NoteService(INoteRepository noteRepository, ICategoryRepository categoryRepository, IMapper mapper)
    {
        _noteRepository = noteRepository;
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }
    
    public ListNotesDto GetAllNotes()
    {
        var notes = _noteRepository.GetAll();
        return _mapper.Map<ListNotesDto>(notes);
    }
    public ListNotesDto SearchByKeyword(string keyword)
    {
        var lowkeyword = keyword.ToLowerInvariant();
        var notes = _noteRepository.GetAll()
            .Where(x => x.Title.Contains(lowkeyword) || x.Content.Contains(lowkeyword));
        return _mapper.Map<ListNotesDto>(notes);
    }
    public NoteDto GetNoteById(long id)
    {
        var note = _noteRepository.GetById(id);
        return _mapper.Map<NoteDto>(note);
    }
    public NoteDto AddNewNote(NoteDtoCreate newNote)
    {
        if (string.IsNullOrEmpty(newNote.Title))
            throw new Exception("Note can not have an empty title");

        var category = _categoryRepository.GetById(newNote.CategoryId);
        if (category == null)
            throw new Exception("This category does not exist");

        var note = _mapper.Map<Note>(newNote);
        note.Detail = new NoteDetail()
        {
            Created = DateTime.Now,
            LastModified = DateTime.Now,
        };
        _noteRepository.Add(note);
        return _mapper.Map<NoteDto>(note);
    }
    public void UpdateNote(long id, NoteDtoUpdate note)
    {
        if (string.IsNullOrEmpty(note.Title))
            throw new Exception("Note can not have an empty title");

        var category = _categoryRepository.GetById(note.CategoryId);
        if (category == null)
            throw new Exception("This category does not exist");
        
        var existingNote = _noteRepository.GetById(id);
        var updatedNote = _mapper.Map(note, existingNote);
        updatedNote.Detail.LastModified = DateTime.Now;
        _noteRepository.Update(updatedNote);
    }
    public void DeleteNote(long id)
    {
        var note = _noteRepository.GetById(id);
        _noteRepository.Delete(note);
    }
}