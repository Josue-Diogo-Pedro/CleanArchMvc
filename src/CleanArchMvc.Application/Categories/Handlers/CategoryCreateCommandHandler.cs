using CleanArchMvc.Application.Categories.Commnads;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Categories.Handlers;

public class CategoryCreateCommandHandler : IRequestHandler<CategoryCreateCommand, Category>
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryCreateCommandHandler(ICategoryRepository categoryRepository) => _categoryRepository = categoryRepository;

    public async Task<Category> Handle(CategoryCreateCommand request, CancellationToken cancellationToken)
    {
        Category category = new(request.Name);

        if (category is null)
            throw new ApplicationException("Error when try to create entity");
        else return await _categoryRepository.CreateAsync(category);
    }
}
