using CleanArchMvc.Application.Categories.Commnads;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Categories.Handlers;

public class CategoryRemoveCommandHandler : IRequestHandler<CategoryRemoveCommand, Category>
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryRemoveCommandHandler(ICategoryRepository categoryRepository) => _categoryRepository = categoryRepository;

    public async Task<Category> Handle(CategoryRemoveCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.Id);

        if (category is null)
            throw new ApplicationException("Error, cold not be found");
        else
            return await _categoryRepository.RemoveAsync(category);
    }
}
