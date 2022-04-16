using Application.DTO.CategoryDto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.Interfaces;

namespace Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }
    
    public IEnumerable<CategoryDto> GetAllCategories()
    {
        var categories = _categoryRepository.GetAll();
        return _mapper.Map<IEnumerable<CategoryDto>>(categories);
    }

    public CategoryDto GetCategoryById(long id)
    {
        var category = _categoryRepository.GetById(id);
        return _mapper.Map<CategoryDto>(category);
    }

    public CategoryDto AddNewCategory(CategoryDtoCreate newCategory)
    {
        if (string.IsNullOrEmpty(newCategory.Name))
            throw new Exception("Category can not have an empty name");

        var categoryWithSameName = _categoryRepository.GetAll().SingleOrDefault(x => x.Name == newCategory.Name);
        if (categoryWithSameName != null)
            throw new Exception("Category with the same name already exist");

        var category = _mapper.Map<Category>(newCategory);
        _categoryRepository.Add(category);
        return _mapper.Map<CategoryDto>(category);
    }

    public void UpdateCategory(long id, CategoryDtoUpdate category)
    {
        if (string.IsNullOrEmpty(category.Name))
            throw new Exception("Category can not have an empty name");

        var categoryWithSameName = _categoryRepository.GetAll().SingleOrDefault(x => x.Name == category.Name);
        if (categoryWithSameName != null)
            throw new Exception("Category with the same name already exist");

        var existingCategory = _categoryRepository.GetById(id);
        var updatedCategory = _mapper.Map(category, existingCategory);
        _categoryRepository.Update(updatedCategory);
    }

    public void DeleteCategory(long id)
    {
        var category = _categoryRepository.GetById(id);
        _categoryRepository.Delete(category);
    }
}