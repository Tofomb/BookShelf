using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShelf.Model;
using BookShelf.DataAccess;
using System.Linq;
using System.Data.Entity;

namespace BookShelf.UI.Data
{
    class BookDataService : IBookDataService
    {
        private Func<BookShelfDBContext> _contextCreator;

        public BookDataService(Func<BookShelfDBContext> contextCreator)
        {
            _contextCreator = contextCreator;
        }


        public async Task<Book> GetByIdAsync(int bookId)
        {
            using (var ctx = _contextCreator())
            {
                return await ctx.Books.AsNoTracking().SingleAsync(b=>b.Id == bookId);
            }
        }

        public async Task SaveAsync(Book book)
        {
            using (var ctx = _contextCreator())
            {
                ctx.Books.Attach(book);
                ctx.Entry(book).State = EntityState.Modified;
                await ctx.SaveChangesAsync();
            }
            // Här sparar till entityframework
        }
    }
}
