using Application.DTO.CategoryDto;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Notebook.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    
    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var categories = _categoryService.GetAllCategories();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public IActionResult Get(long id)
    {
        var category = _categoryService.GetCategoryById(id);
        if (category == null) return NotFound();
        return Ok(category);
    }

    [HttpPost]
    public IActionResult Create(CategoryDtoCreate newCategory)
    {
        var category = _categoryService.AddNewCategory(newCategory);
        return Created($"categories/{category.Id}", category);
    }

    [HttpPut("{id}")]
    public IActionResult Update(long id, CategoryDtoUpdate updateCategory)
    {
        _categoryService.UpdateCategory(id, updateCategory);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        _categoryService.DeleteCategory(id);
        return NoContent();
    }
}