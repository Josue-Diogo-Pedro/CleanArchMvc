using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Products.Queries;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Services._Product;

public class ProductService : IProductService
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ProductService(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
    {
        var productsQuery = new GetProductsQuery();

        if (productsQuery is null)
            throw new Exception("Entity cold not be loaded.");

        return _mapper.Map<IEnumerable<ProductDTO>>(await _mediator.Send(productsQuery));
    }

    //public async Task<ProductDTO> GetProductCategoryAsync(int? id)
    //{
    //    var product = await _productRepository.GetProductCategoryAsync(id);
    //    return _mapper.Map<ProductDTO>(product);
    //}

    //public async Task<ProductDTO> GetByIdAsync(int? id)
    //{
    //    var product = await _productRepository.GetByIdAsync(id);
    //    return _mapper.Map<ProductDTO>(product);
    //}

    //public async Task CreateAsync(ProductDTO product) => 
    //    await _productRepository.CreateAsync(_mapper.Map<Product>(product));

    //public async Task UpdateAsync(ProductDTO product) => 
    //    await _productRepository.UpdateAsync(_mapper.Map<Product>(product));

    //public async Task RemoveAsync(int? productId) => 
    //    await _productRepository.RemoveAsync(await _productRepository.GetByIdAsync(productId));

}
