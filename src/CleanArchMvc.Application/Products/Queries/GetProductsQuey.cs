using CleanArchMvc.Domain.Entities;
using MediatR;

namespace CleanArchMvc.Application.Products.Queries;

public class GetProductsQuey : IRequest<IEnumerable<Product>>
{
}
