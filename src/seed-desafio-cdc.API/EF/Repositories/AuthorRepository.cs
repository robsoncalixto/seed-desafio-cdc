
using Microsoft.EntityFrameworkCore;

namespace seed_desafio_cdc.API;

public class AuthorRepository : IAuthorRepository
{
    private readonly DataBaseContextInMemory _context;

    public AuthorRepository(DataBaseContextInMemory context)
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
}
