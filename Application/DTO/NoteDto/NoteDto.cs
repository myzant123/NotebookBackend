namespace Application.DTO;

public class NoteDto
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    
    public CategoryDto.CategoryDto Category { get; set; }
    public DateTime LastModified { get; set; }
}