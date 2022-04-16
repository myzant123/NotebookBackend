namespace Application.DTO;

public class NoteDtoCreate
{
    public string Title { get; set; }
    public string Content { get; set; }
    
    public long CategoryId { get; set; }
}