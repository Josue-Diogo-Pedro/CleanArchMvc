using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Products.Handlers;

public class ProductCreateCommnadHandler : IRequestHandler<ProductCreateCommnad, Product>
{
    private readonly IProductRepository _productRepository;

    public ProductCreateCommnadHandler(IProductRepository productRepository) => _productRepository = productRepository;

    public Task<Product> Handle(ProductCreateCommnad request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
