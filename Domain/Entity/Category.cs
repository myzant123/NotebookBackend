namespace Domain.Entity;

public class Category
{
    public long Id { get; set; }
    public string Name { get; set; }
    
    public ICollection<Note> Notes { get; set; }
}