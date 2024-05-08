using CleanArchMvc.Application.DTOs;

namespace CleanArchMvc.Application.Services._Category;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDTO>> GetCategoriesAsync();
    Task<CategoryDTO> GetByIdAsync(int? id);

    Task<CategoryDTO> CreateAsync(CategoryDTO category);
    Task<CategoryDTO> UpdateAsync(CategoryDTO category);
    Task<CategoryDTO> RemoveAsync(CategoryDTO category);
}
