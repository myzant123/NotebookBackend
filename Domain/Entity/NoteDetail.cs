namespace Domain.Entity;

public class NoteDetail
{
    public long Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime LastModified { get; set; }
    
    public long NoteId { get; set; }
    public Note Note { get; set; }
}