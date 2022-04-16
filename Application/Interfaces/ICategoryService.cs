using Application.DTO.CategoryDto;

namespace Application.Interfaces;

public interface ICategoryService
{
    IEnumerable<CategoryDto> GetAllCategories();
    CategoryDto GetCategoryById(long id);
    CategoryDto AddNewCategory(CategoryDtoCreate newCategory);
    void UpdateCategory(long id, CategoryDtoUpdate category);
    void DeleteCategory(long id);
}