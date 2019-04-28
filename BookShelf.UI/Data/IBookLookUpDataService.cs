using System.Collections.Generic;
using System.Threading.Tasks;
using BookShelf.Model;

namespace BookShelf.UI.Data
{
    public interface IBookLookUpDataService
    {
        Task<IEnumerable<LookUpItem>> GetBookLookupAsync();
    }
}