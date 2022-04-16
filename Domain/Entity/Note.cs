namespace Domain.Entity;

public class Note
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    
    public NoteDetail Detail { get; set; }
    public long CategoryId { get; set; }
    public Category Category { get; set; }
}