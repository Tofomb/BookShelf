namespace BookShelf.DataAccess.Migrations
{
    using BookShelf.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BookShelfDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BookShelfDBContext context)
        {
            context.Books.AddOrUpdate(
                b => b.Title,
                 new Book { Title = "Lord of THe Rings", Author = "J.R.R.Tolkien" },
              new Book { Title = "The Hobbit", Author = "J.R.R.Tolkien" },
              new Book { Title = "The Silver Chair", Author = "C.S. Lewies" },
              new Book { Title = "THHGTG", Author = "Douglas Adams" }


                );
        }
    }
}
