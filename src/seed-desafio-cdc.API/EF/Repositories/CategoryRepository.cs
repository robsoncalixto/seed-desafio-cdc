using Microsoft.EntityFrameworkCore;

namespace seed_desafio_cdc.API;

public class CategoryRepository : ICategoryRepository
{
    private readonly DbContextPostgres _context;

    public CategoryRepository(DbContextPostgres context)
    {
        _context = context;
    }

     public async Task<Category> SaveAsync(Category category)
    {
        await _context.AddAsync(category);
        await _context.SaveChangesAsync();
        return category;
    }
  
    public async Task<Category> FindByNameAsync(string? name)
    {
        var category =  await _context.Categories.SingleOrDefaultAsync(x => x.Name == name);
        return category!;
    }
    
    public async Task<List<Category>> FindAllAsync() 
    {
        return await _context.Categories.ToListAsync();
    } 
}
