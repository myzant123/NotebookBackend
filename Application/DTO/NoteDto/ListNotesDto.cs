namespace Application.DTO;

public class ListNotesDto
{
    public long Count { get; set; }
    public IEnumerable<NoteDto> Notes { get; set; }
}