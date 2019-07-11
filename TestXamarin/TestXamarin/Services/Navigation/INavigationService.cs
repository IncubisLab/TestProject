using System.Threading.Tasks;
using TestXamarin.Pages;

namespace TestXamarin.Services.Navigation
{
    public interface INavigationService
    {
        Task NavigateToAsync<TPage>() where TPage : BasePage, new();
        Task NavigateToAsync<TPage>(object navigationData) where TPage : BasePage, new();
        void GoBack();
    }
}
