using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Products.Handlers;

public class ProductUpdateCommnadHandler : IRequestHandler<ProductUpdateCommnad, Product>
{
    private readonly IProductRepository _productRepository;

    public ProductUpdateCommnadHandler(IProductRepository productRepository) => _productRepository = productRepository;

    public Task<Product> Handle(ProductUpdateCommnad request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
