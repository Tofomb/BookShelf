using BookShelf.Model;
using BookShelf.UI.Data;
using BookShelf.UI.Event;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShelf.UI.ViewModel
{
    public class NavigationViewModel :ViewModelBase, INavigationViewModel
    {
        private IEventAggregator _eventAggregator;
        private IBookLookUpDataService _bookLookUpDataService;

        public NavigationViewModel(IBookLookUpDataService bookLookUpDataService,
            IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _bookLookUpDataService = bookLookUpDataService;
            Books = new ObservableCollection<LookUpItem>();
        }
        public async Task LoadAsync()
        {
            var lookUp = await _bookLookUpDataService.GetBookLookupAsync();
            Books.Clear();
            foreach(var item in lookUp)
            {
                Books.Add(item);
            }
        }


        public ObservableCollection<LookUpItem> Books { get; }
        private LookUpItem _selectedBook;

        public LookUpItem SelectedBook
        { 
            get { return _selectedBook; }
            set {
                _selectedBook = value;
                OnPropertyChanged();
                if (_selectedBook != null)
                {
                    _eventAggregator.GetEvent<OpenBookDetailViewEvent>()
                        .Publish(_selectedBook.Id);
                }
            }
        }

    }
}
