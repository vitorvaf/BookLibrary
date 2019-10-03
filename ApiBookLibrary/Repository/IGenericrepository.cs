using System.Linq;
using System.Threading.Tasks;

namespace ApiBookLibrary.Repository
{
    public interface IGenericrepository<T>
    {
        Task<T> GetAsync(int id);

        IQueryable<T> Query();

        Task InsertAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(int id);
         
    }
}