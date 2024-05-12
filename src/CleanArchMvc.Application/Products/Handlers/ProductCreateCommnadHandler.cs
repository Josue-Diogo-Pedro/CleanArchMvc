using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Products.Handlers;

public class ProductCreateCommnadHandler : IRequestHandler<ProductCreateCommnad, Product>
{
    private readonly IProductRepository _productRepository;

    public ProductCreateCommnadHandler(IProductRepository productRepository) => _productRepository = productRepository;

    public async Task<Product> Handle(ProductCreateCommnad request, CancellationToken cancellationToken)
    {
        var product = new Product(request.Name, request.Description, request.Price.Value, request.Stock, request.Image);

        if (product is null)
            throw new ApplicationException("Error when try to create entity");
        else
        {
            product.CategoryId = request.CategoryId;
            return await _productRepository.CreateAsync(product);
        }
    }
}
