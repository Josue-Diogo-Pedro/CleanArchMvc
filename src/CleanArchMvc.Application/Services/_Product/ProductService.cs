using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Services._Product;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
    {
        var products = await _productRepository.GetProductsAsync();
        return _mapper.Map<IEnumerable<ProductDTO>>(products);
    }

    public async Task<ProductDTO> GetProductCategoryAsync(int? id)
    {
        var product = await _productRepository.GetProductCategoryAsync(id);
        return _mapper.Map<ProductDTO>(product);
    }

    public async Task<ProductDTO> GetByIdAsync(int? id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        return _mapper.Map<ProductDTO>(product);
    }

    public Task<ProductDTO> CreateAsync(ProductDTO product)
    {
        throw new NotImplementedException();
    }

    public Task<ProductDTO> UpdateAsync(ProductDTO product)
    {
        throw new NotImplementedException();
    }

    public Task<ProductDTO> RemoveAsync(ProductDTO product)
    {
        throw new NotImplementedException();
    }

}
