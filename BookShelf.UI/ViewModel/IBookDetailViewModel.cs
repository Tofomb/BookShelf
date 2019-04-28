using System.Threading.Tasks;

namespace BookShelf.UI.ViewModel
{
    public interface IBookDetailViewModel
    {
        Task LoadAsync(int bookId);
    }
}