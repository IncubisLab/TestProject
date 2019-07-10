using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TestXamarin.Exceptions;
using TestXamarin.IoC;
using TestXamarin.Pages;
using TestXamarin.ViewModels;
using Xamarin.Forms;

namespace TestXamarin.Services.Navigation
{
    public class NavigationService: INavigationService
    {
        public Task NavigateToAsync<TPage>() where TPage : BasePage, new()
        {
            return InternalNavigateToAsync(typeof(TPage), null);
        }

        public Task NavigateToAsync<TPage>(object navigationData) where TPage : BasePage, new()
        {
            return InternalNavigateToAsync(typeof(TPage), navigationData);
        }

        public void GoBack()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await GetTopNavigation().PopAsync();
            });
        }

        private async Task InternalNavigateToAsync(Type pageType, object viewModelParameter)
        {
            if (pageType == null) throw new ArgumentNullException(nameof(pageType));
            try
            {
                // Resolve Page and ViewModel
                if (!(Activator.CreateInstance(pageType) is Page page))
                    throw new Exception($@"Page instance for {pageType.Name} is Null");

                var viewModelType = GetViewModelType(pageType);

                if (viewModelType.BaseType?.FullName != typeof(BaseViewModel).FullName)
                    throw new Exception($"{viewModelType.Name} must be inherited from BaseViewModel");

                var viewModel = Locator.Resolve(viewModelType);

                page.BindingContext = viewModel;

                // Seed
                if (page.BindingContext is BaseViewModel baseViewModel)
                {
                    await baseViewModel.InitializeAsync(viewModelParameter);
                }

                // Navigate
                await GetTopNavigation().PushAsync(page);
            }
            catch (Exception e)
            {
                throw new NavigationException($@"Unable to navigate to {pageType.Name}. See inner exception", e);
            }
        }

        private INavigation GetTopNavigation()
        {
            var mainPage = Application.Current.MainPage;
            if (mainPage is MasterDetailPage masterDetailPage)
            {
                if (masterDetailPage.Detail is NavigationPage navigationPage)
                {
                    var modalStack = navigationPage.Navigation.ModalStack.OfType<NavigationPage>().ToList();
                    if (modalStack.Any())
                    {
                        return modalStack.LastOrDefault()?.Navigation;
                    }
                    return navigationPage.Navigation;
                }
            }
            return (mainPage as NavigationPage)?.Navigation;
        }

        private Type GetViewModelType(Type pageType)
        {
            if (pageType == null) throw new ArgumentNullException(nameof(pageType));

            var viewModelName = pageType.FullName?.Replace("Page", "ViewModel");
            var pageAssemblyName = pageType.GetTypeInfo().Assembly.FullName;
            var viewModelAssemblyName = string.Format(
                CultureInfo.InvariantCulture, "{0}, {1}", viewModelName, pageAssemblyName);
            var viewModelType = Type.GetType(viewModelAssemblyName);
            return viewModelType;
        }
    }
}
