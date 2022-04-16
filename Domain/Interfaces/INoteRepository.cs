using Domain.Entity;

namespace Domain.Interfaces;

public interface INoteRepository
{
    IQueryable<Note> GetAll();
    Note GetById(long id);
    Note Add(Note note);
    void Update(Note note);
    void Delete(Note note);
}