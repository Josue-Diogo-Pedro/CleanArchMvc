using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Products.Handlers;

public class ProductUpdateCommnadHandler : IRequestHandler<ProductUpdateCommnad, Product>
{
    private readonly IProductRepository _productRepository;

    public ProductUpdateCommnadHandler(IProductRepository productRepository) => _productRepository = productRepository;

    public async Task<Product> Handle(ProductUpdateCommnad request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id);

        if (product is null)
            throw new ApplicationException("Error, cold not be found");
        else
        {
            product.Update(request.Name, request.Description, request.Price.Value, request.Stock, request.Image, request.CategoryId);
            return await _productRepository.UpdateAsync(product);
        }
    }
}
