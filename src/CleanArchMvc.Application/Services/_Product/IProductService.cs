using CleanArchMvc.Application.DTOs;

namespace CleanArchMvc.Application.Services._Product;

public interface IProductService
{
    Task<IEnumerable<ProductDTO>> GetProductsAsync();
    Task<ProductDTO> GetByIdAsync(int? id);

    Task<ProductDTO> GetProductCategoryAsync(int? id);

    Task CreateAsync(ProductDTO product);
    Task UpdateAsync(ProductDTO product);
    Task RemoveAsync(int? productId);
}
