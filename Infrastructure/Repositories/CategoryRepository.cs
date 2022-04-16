using Domain.Entity;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly NotebookContext _context;
    
    public CategoryRepository(NotebookContext context)
    {
        _context = context;
    }
    
    public IQueryable<Category> GetAll()
    {
        return _context.Categories;
    }
    public Category GetById(long id)
    {
        return _context.Categories.SingleOrDefault(x => x.Id == id) ?? throw new InvalidOperationException();
    }
    public Category Add(Category category)
    {
        _context.Categories.Add(category);
        _context.SaveChanges();
        return category;
    }
    public void Update(Category category)
    {
        _context.Categories.Update(category);
        _context.SaveChanges();
    }
    public void Delete(Category category)
    {
        _context.Categories.Remove(category);
        _context.SaveChanges();
    }
}