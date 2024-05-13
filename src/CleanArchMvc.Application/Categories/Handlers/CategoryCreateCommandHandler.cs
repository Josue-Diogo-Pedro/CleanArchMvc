using CleanArchMvc.Application.Categories.Commnads;
using CleanArchMvc.Domain.Entities;
using MediatR;

namespace CleanArchMvc.Application.Categories.Handlers;

public class CategoryCreateCommandHandler : IRequestHandler<CategoryCreateCommand, Category>
{
    public Task<Category> Handle(CategoryCreateCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
