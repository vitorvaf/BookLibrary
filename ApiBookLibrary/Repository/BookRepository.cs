using ApiBookLibrary.Models;
using ApiBookLibrary.Data;

namespace ApiBookLibrary.Repository
{
    public class BookRepository : GenericRepository<BookModel>, IBookRepository
    {
        public BookRepository(BookLibraryDataContext dbContext)
        {
            _dbContext = dbContext;            
        }            
    }
}