namespace seed_desafio_cdc.API;

public interface IAuthorRepository
{
    Task<Author> SaveAsync(Author author);
    Task<IEnumerable<Author>> ListAsync();
    Task<Author?> FindByEmailAsync(string email);
}
