using Application.DTO;

namespace Application.Interfaces;

public interface INoteService
{
    ListNotesDto GetAllNotes();
    public ListNotesDto SearchByKeyword(string keyword);
    NoteDto GetNoteById(long id);
    NoteDto AddNewNote(NoteDtoCreate newNote);
    void UpdateNote(long id, NoteDtoUpdate note);
    void DeleteNote(long id);
}