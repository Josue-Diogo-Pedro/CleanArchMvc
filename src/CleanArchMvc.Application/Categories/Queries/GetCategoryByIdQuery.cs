using CleanArchMvc.Domain.Entities;
using MediatR;

namespace CleanArchMvc.Application.Categories.Queries;

public class GetCategoryByIdQuery : IRequest<Category>
{
    public int Id { get; set; }

    public GetCategoryByIdQuery(int id) => Id = id;
}
