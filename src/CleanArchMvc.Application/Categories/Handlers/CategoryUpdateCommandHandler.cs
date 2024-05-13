using CleanArchMvc.Application.Categories.Commnads;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Categories.Handlers;

public class CategoryUpdateCommandHandler : IRequestHandler<CategoryUpdateCommand, Category>
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryUpdateCommandHandler(ICategoryRepository categoryRepository) => _categoryRepository = categoryRepository;

    public async Task<Category> Handle(CategoryUpdateCommand request, CancellationToken cancellationToken)
    {
        Category category = await _categoryRepository.GetByIdAsync(request.Id);

        if (category is null)
            throw new ApplicationException("Error, cold not be found");
        else
        {
            category.Update(request.Name);
            return await _categoryRepository.UpdateAsync(category);
        }
    }
}
