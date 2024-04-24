using Microsoft.EntityFrameworkCore;
using SES.Domain.Entities;

namespace SES.Data.Access.EF.Contexts;

public class MainDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    
    public MainDbContext(DbContextOptions<MainDbContext> options)
        : base(options)
    {
    }
}