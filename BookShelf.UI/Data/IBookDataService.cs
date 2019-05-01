using System.Collections.Generic;
using System.Threading.Tasks;
using BookShelf.Model;

namespace BookShelf.UI.Data
{
    public interface IBookDataService
    {
        Task<Book> GetByIdAsync(int bookId);
        Task SaveAsync(Book book);
    }
}