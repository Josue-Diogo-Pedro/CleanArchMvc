using CleanArchMvc.Domain.Entities;
using MediatR;

namespace CleanArchMvc.Application.Categories.Commnads;

public abstract class CategoryCommand : IRequest<Category>
{
    public string? Name { get; private set; }
}
