using Microsoft.EntityFrameworkCore;

namespace seed_desafio_cdc.API;

public class DataBaseContextInMemory : DbContext
{
    public DataBaseContextInMemory(DbContextOptions<DataBaseContextInMemory> options) : base (options)
    {        
    }
    public DbSet<Author> Authors { get; set; }
}
