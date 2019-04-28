using Autofac;
using BookShelf.DataAccess;
using BookShelf.UI.Data;
using BookShelf.UI.ViewModel;
using Prism.Events;
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

            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<NavigationViewModel>().As<INavigationViewModel>();
            builder.RegisterType<BookDetailViewModel>().As<IBookDetailViewModel>();


            builder.RegisterType<LookUpDataService>().AsImplementedInterfaces();
            builder.RegisterType<BookDataService>().As<IBookDataService>();

            return builder.Build();

        }

    }
}
