using Domain.Entity;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class NoteRepository : INoteRepository
{
    private readonly NotebookContext _context;
    
    public NoteRepository(NotebookContext context)
    {
        _context = context;
    }
    
    public IQueryable<Note> GetAll()
    {
        return _context.Notes
            .Include(x => x.Detail)
            .Include(x => x.Category);
    }
    public Note GetById(long id)
    {
        return _context.Notes
            .Include(x => x.Detail)
            .Include(x => x.Category)
            .SingleOrDefault(x => x.Id == id) ?? throw new InvalidOperationException();
    }
    public Note Add(Note note)
    {
        _context.Notes.Add(note);
        _context.SaveChanges();
        return note;
    }
    public void Update(Note note)
    {
        _context.Notes.Update(note);
        _context.SaveChanges();
    }
    public void Delete(Note note)
    {
        _context.Notes.Remove(note);
        _context.SaveChanges();
    }
}