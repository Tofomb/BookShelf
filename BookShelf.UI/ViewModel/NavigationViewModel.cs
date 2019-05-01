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
            Books = new ObservableCollection<NavigationItemViewModel>();
            _eventAggregator.GetEvent<AfterBookSaveEvent>().Subscribe(AfterBookSave);
        }

        private void AfterBookSave(AfterBookSaveEventArgs obj)
        {
          var lookUpItem = Books.Single(b => b.Id == obj.Id);
            lookUpItem.DisplayMember = obj.DisplayMember;
        }

        public async Task LoadAsync()
        {
            var lookUp = await _bookLookUpDataService.GetBookLookupAsync();
            Books.Clear();
            foreach(var item in lookUp)
            {
                Books.Add(new NavigationItemViewModel(item.Id,item.DisplayMember));
            }
        }


        public ObservableCollection<NavigationItemViewModel> Books { get; }
        private NavigationItemViewModel _selectedBook;

        public NavigationItemViewModel SelectedBook
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
