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

        public MainViewModel(IBookDataService bookDataService)
        {
            Books = new ObservableCollection<Book>();
            _bookDataService = bookDataService;
        }

        public async Task LoadAsync()
        {
            var books = await _bookDataService.GetAllAsync();
            Books.Clear();
            foreach (var book in books)
            {
                Books.Add(book);
            }
        }

        public ObservableCollection<Book> Books { get; set; }
       

        public Book SelectedBook
        {
            get { return _selectedBook; }
            set { _selectedBook = value;
                OnPropertyChanged();
            }
            
        }

       

    }
}
