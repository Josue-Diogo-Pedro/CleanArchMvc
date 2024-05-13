using CleanArchMvc.Domain.Entities;
using MediatR;

namespace CleanArchMvc.Application.Categories.Queries;

public class GetCategoriesQuery : IRequest<IEnumerable<Category>>
{
}
