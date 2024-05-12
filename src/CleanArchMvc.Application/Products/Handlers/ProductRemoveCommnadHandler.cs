using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Products.Handlers;

public class ProductRemoveCommnadHandler : IRequestHandler<ProductRemoveCommand, Product>
{
    private readonly IProductRepository _productRepository;

    public ProductRemoveCommnadHandler(IProductRepository productRepository) => _productRepository = productRepository;

    public Task<Product> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
