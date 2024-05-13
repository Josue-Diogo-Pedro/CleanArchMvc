using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Products.Commands;
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
        GetProductsQuery productsQuery = new();

        if (productsQuery is null)
            throw new Exception("Entity cold not be loaded.");

        return _mapper.Map<IEnumerable<ProductDTO>>(await _mediator.Send(productsQuery));
    }

    public async Task<ProductDTO> GetProductCategoryAsync(int? id)
    {
        GetProductByIdQuery productByIdQuery = new(id.Value);

        if (productByIdQuery is null)
            throw new Exception("Entity cold not be found");

        return _mapper.Map<ProductDTO>(await _mediator.Send(productByIdQuery));
    }

    public async Task<ProductDTO> GetByIdAsync(int? id)
    {
        GetProductByIdQuery productByIdQuery = new(id.Value);

        if (productByIdQuery is null)
            throw new Exception("Entity cold not be found");

        return _mapper.Map<ProductDTO>(await _mediator.Send(productByIdQuery));
    }

    public async Task CreateAsync(ProductDTO product) => 
        await _mediator.Send(_mapper.Map<ProductCreateCommnad>(product));

    public async Task UpdateAsync(ProductDTO product) =>
        await _mediator.Send(_mapper.Map<ProductUpdateCommnad>(product));

    public async Task RemoveAsync(int? productId)
    {
        ProductRemoveCommand productRemoveCommand = new(productId.Value);

        if (productRemoveCommand is null)
            throw new Exception("Entity cold not be loaded");

        await _mediator.Send(productRemoveCommand);
    }

}
