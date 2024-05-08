using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _context;

    public CategoryRepository(ApplicationDbContext context) => _context = context;

    public async Task<IEnumerable<Category>> GetCategoriesAsync() => await _context.Categories?
                                                                            .AsNoTracking()?
                                                                            .DefaultIfEmpty()?
                                                                            .ToListAsync();

    public async Task<Category> GetByIdAsync(int? id) => await _context.Categories?
                                                                .AsNoTracking()?
                                                                .DefaultIfEmpty()?
                                                                .SingleOrDefaultAsync(category => category.Id == id);
    
    public Task<Category> CreateAsync(Category category)
    {
        throw new NotImplementedException();
    }
    public Task<Category> UpdateAsync(Category category)
    {
        throw new NotImplementedException();
    }



    public Task<Category> RemoveAsync(Category category)
    {
        throw new NotImplementedException();
    }


    private async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
}
