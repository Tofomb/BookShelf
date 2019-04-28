using Autofac;
using BookShelf.DataAccess;
using BookShelf.UI.Data;
using BookShelf.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShelf.UI.Startup
{
    public class Bootstraper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<BookShelfDBContext>().AsSelf();


            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<BookDataService>().As<IBookDataService>();

            return builder.Build();

        }

    }
}
