// using Microsoft.EntityFrameworkCore;

// using BookAPI.Models;

// namespace BookManagementSystem.Data
// {
//     public class AppDbContext : DbContext
//     {
//         public AppDbContext(DbContextOptions<AppDbContext> options)
//             : base(options) { }

//         public DbSet<Book> Books { get; set; }
//     }
// }



using Microsoft.EntityFrameworkCore;
using BookAPI.Models;

namespace BookManagementSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Book> Books { get; set; }
    }
}