using AutoMapper;
using CleanArchMvc.Application.Categories.Queries;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Domain.Entities;
using MediatR;

namespace CleanArchMvc.Application.Services._Category;

public class CategoryService : ICategoryService
{
	private readonly IMediator _mediator;
	private readonly IMapper _mapper;

	public CategoryService(IMediator mediator, IMapper mapper)
	{
		_mediator = mediator;
		_mapper = mapper;
	}

	public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
	{
		GetCategoriesQuery categoriesQuery = new();
		if (categoriesQuery is null)
			throw new Exception("Entity cold not be loaded");

		return _mapper.Map<IEnumerable<CategoryDTO>>(await _mediator.Send(categoriesQuery));
	}

	public async Task<CategoryDTO> GetByIdAsync(int? id)
	{
		GetCategoryByIdQuery categoryByIdQuery = new(id.Value);

		if (categoryByIdQuery is null)
			throw new Exception("Entity cold not be loaded");

		return _mapper.Map<CategoryDTO>(await _mediator.Send(categoryByIdQuery));
	}

	public async Task CreateAsync(CategoryDTO category) =>
		await _categoryRepository.CreateAsync(_mapper.Map<Category>(category));

	public async Task UpdateAsync(CategoryDTO category) =>
		await _categoryRepository.UpdateAsync(_mapper.Map<Category>(category));

	public async Task RemoveAsync(int? categoryId) =>
		await _categoryRepository.RemoveAsync(await _categoryRepository.GetByIdAsync(categoryId));

}
