using Domain.Entity;

namespace Domain.Interfaces;

public interface ICategoryRepository
{
    IQueryable<Category> GetAll();
    Category GetById(long id);
    Category Add(Category category);
    void Update(Category category);
    void Delete(Category category);
}