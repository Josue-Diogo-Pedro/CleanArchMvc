using CleanArchMvc.Application.Categories.Queries;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Categories.Handlers;

public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, Category>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoryByIdHandler(ICategoryRepository categoryRepository) => _categoryRepository = categoryRepository;

    public async Task<Category> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken) =>
        await _categoryRepository.GetByIdAsync(request.Id);
}
