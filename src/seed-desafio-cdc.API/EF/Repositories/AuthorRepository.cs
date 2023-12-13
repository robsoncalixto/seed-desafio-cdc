
using Microsoft.EntityFrameworkCore;

namespace seed_desafio_cdc.API;

public class AuthorRepository : IAuthorRepository
{
    private readonly DbContextPostgres _context;

    public AuthorRepository(DbContextPostgres context)
    {
        _context = context;
    }

    public async Task<Author> SaveAsync(Author author)
    {
       _context.Add(author);
       await _context.SaveChangesAsync();
       return author;
        
    }
    public async Task<IEnumerable<Author>> ListAsync(){
        return await _context.Authors.ToListAsync();
    }

    public Task<Author?> FindByEmailAsync(string email)
    {
        var author = _context.Authors.Where( a => a.Email == email).FirstOrDefaultAsync();
        return author;
    }
}
