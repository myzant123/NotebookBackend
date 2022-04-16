namespace Application.DTO;

public class NoteDtoUpdate
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    
    public long CategoryId { get; set; }
}