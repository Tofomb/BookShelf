using BookShelf.DataAccess;
using BookShelf.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShelf.UI.Data
{
    public class LookUpDataService : IBookLookUpDataService
    {
        private Func<BookShelfDBContext> _contextCreator;

        public LookUpDataService(Func<BookShelfDBContext> contextCreator)
        {
            _contextCreator = contextCreator;
        }

        public async Task<IEnumerable<LookUpItem>> GetBookLookupAsync()
        {
            using (var ctx = _contextCreator())
            {
                return await ctx.Books.AsNoTracking()
                    .Select(b =>
                    new LookUpItem
                    {
                        Id = b.Id,
                        DisplayMember = b.Title // + b.Author
                    })
                    .ToListAsync();
            }

        }
    }
}
