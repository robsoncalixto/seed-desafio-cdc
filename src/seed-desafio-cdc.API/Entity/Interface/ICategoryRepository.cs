namespace seed_desafio_cdc.API;

public interface ICategoryRepository
{
    Task<Category> SaveAsync(Category category);    
    Task<Category> FindByNameAsync(string? name);
    Task<List<Category>> FindAllAsync();
}
