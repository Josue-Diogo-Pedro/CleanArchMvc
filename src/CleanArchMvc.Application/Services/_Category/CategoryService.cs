using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Services._Category;

public class CategoryService : ICategoryService
{
	private readonly ICategoryRepository _categoryRepository;
	private readonly IMapper _mapper;

	public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
	{
        _categoryRepository = categoryRepository;
		_mapper = mapper;
	}

	public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
	{
		var categories = await _categoryRepository.GetCategoriesAsync();
		return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
	}

	public async Task<CategoryDTO> GetByIdAsync(int? id)
	{
		var category = await _categoryRepository.GetByIdAsync(id);
		return _mapper.Map<CategoryDTO>(category);
	}

	public async Task<CategoryDTO> CreateAsync(CategoryDTO category)
	{
		
	}

	public Task<CategoryDTO> UpdateAsync(CategoryDTO category)
	{
		throw new NotImplementedException();
	}

	public Task<CategoryDTO> RemoveAsync(CategoryDTO category)
	{
		throw new NotImplementedException();
	}

}
