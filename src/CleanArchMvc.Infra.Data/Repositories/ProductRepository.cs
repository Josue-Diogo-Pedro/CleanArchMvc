using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context) => _context = context;

    public async Task<IEnumerable<Product>> GetProductsAsync() => await _context.Products?
                                                                        .AsNoTracking()?
                                                                        .DefaultIfEmpty()?
                                                                        .ToListAsync();

    public async Task<Product> GetProductCategoryAsync(int? id) => await _context.Products?
                                                                            .AsNoTracking()?
                                                                            .DefaultIfEmpty()?
                                                                            .Include(category => category.Category)?
                                                                            .SingleOrDefaultAsync(product => product.Id == id);

    public Task<Product> GetByIdAsync(int? id)
    {
        throw new NotImplementedException();
    }
    public Task<Product> CreateAsync(Product product)
    {
        throw new NotImplementedException();
    }

    public Task<Product> UpdateAsync(Product product)
    {
        throw new NotImplementedException();
    }
    public Task<Product> RemoveAsync(Product product)
    {
        throw new NotImplementedException();
    }

    private async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

}
