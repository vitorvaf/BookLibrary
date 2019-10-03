using Microsoft.EntityFrameworkCore;
using ApiBookLibrary.Models;

namespace ApiBookLibrary.Data
{
    public class BookLibraryDataContext : DbContext
    {

        public DbSet<BookModel> Books {get; set;}
        public DbSet<AuthorModel> Authors  { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseInMemoryDatabase();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
        }

        
    }
}