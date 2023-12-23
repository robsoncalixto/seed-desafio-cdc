using Microsoft.EntityFrameworkCore;

namespace seed_desafio_cdc.API;

public class DbContextPostgres : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbContextPostgres(DbContextOptions<DbContextPostgres> options) : base(options){ }         
}
