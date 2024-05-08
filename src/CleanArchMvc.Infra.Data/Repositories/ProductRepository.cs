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

    public async Task<Product> GetByIdAsync(int? id) => await _context.Products?
                                                                .AsNoTracking()?
                                                                .DefaultIfEmpty()?
                                                                .SingleOrDefaultAsync(product => product.Id == id);

    public async Task<Product> CreateAsync(Product product)
    {
        await _context.Products.AddAsync(product);
        await SaveChangesAsync();

        return product;
    }

    public async Task<Product> UpdateAsync(Product product)
    {
        _context.Products.Update(product);
        await SaveChangesAsync();

        return product;
    }

    public async Task<Product> RemoveAsync(Product product)
    {
        _context.Products.Remove(product);
        await SaveChangesAsync();

        return product;
    }

    private async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

}
