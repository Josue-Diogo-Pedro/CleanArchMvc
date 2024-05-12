using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Domain.Entities;
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

    public async Task CreateAsync(ProductDTO product) => 
        await _productRepository.CreateAsync(_mapper.Map<Product>(product));

    public async Task UpdateAsync(ProductDTO product) => 
        await _productRepository.UpdateAsync(_mapper.Map<Product>(product));

    public async Task RemoveAsync(int? productId) => 
        await _productRepository.RemoveAsync(await _productRepository.GetByIdAsync(productId));

}
