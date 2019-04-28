using BookShelf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using BookShelf.UI.Data;

namespace BookShelf.UI.ViewModel
{
    public class MainViewModel:ViewModelBase
    {
        private Book _selectedBook;
        private IBookDataService _bookDataService;

        public MainViewModel(INavigationViewModel navigationViewModel,
            IBookDetailViewModel bookDetailViewModel)
        {
            NavigationViewModel = navigationViewModel;
            BookDetailViewModel = bookDetailViewModel;
        }

        public async Task LoadAsync()
        {
            await NavigationViewModel.LoadAsync();
        }

        public INavigationViewModel NavigationViewModel { get; }

        public IBookDetailViewModel BookDetailViewModel { get; }

    }
}
