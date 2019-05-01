using BookShelf.Model;
using BookShelf.UI.Data;
using BookShelf.UI.Event;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BookShelf.UI.ViewModel
{
    public class BookDetailViewModel : ViewModelBase, IBookDetailViewModel
    {
        private IBookDataService _dataService;
        private IEventAggregator _eventAggregator;

        public BookDetailViewModel(IBookDataService dataService,
            IEventAggregator eventAggregator)
        {
            _dataService = dataService;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<OpenBookDetailViewEvent>()
                .Subscribe(OnOpenBookDetailView);


            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
        }

        private bool OnSaveCanExecute()
        {
            return true;
        }

        private async void OnSaveExecute()
        {
            await _dataService.SaveAsync(Book);
            _eventAggregator.GetEvent<AfterBookSaveEvent>().Publish(
                new AfterBookSaveEventArgs
                {
                    Id = Book.Id,
                    DisplayMember = Book.Title
                });
        }

        private async void OnOpenBookDetailView(int bookId)
        {
            await LoadAsync(bookId);
        }


        public async Task LoadAsync(int bookId)
        {
            Book = await _dataService.GetByIdAsync(bookId);
        }
        private Book _book;
        //Viktig propertychange
        public Book Book
        {
            get { return _book; }
            private set
            {
                _book = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }
    }
}
