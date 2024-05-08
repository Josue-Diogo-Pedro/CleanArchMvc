using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Application.Services._Product;

public interface IProductService
{
    Task<IEnumerable<ProductDTO>> GetProductsAsync();
    Task<ProductDTO> GetByIdAsync(int? id);

    Task<ProductDTO> GetProductCategoryAsync(int? id);

    Task<ProductDTO> CreateAsync(ProductDTO product);

    Task<ProductDTO> UpdateAsync(ProductDTO product);
    Task<ProductDTO> RemoveAsync(ProductDTO product);
}
