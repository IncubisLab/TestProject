using System.Threading.Tasks;
using TestXamarin.ViewModel;
using Xamarin.Forms;

namespace TestXamarin.Pages
{
    public class BasePage : ContentPage
    {
        protected BaseViewModel BaseViewModel => BindingContext as BaseViewModel;

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Task.Run(async () =>
            {
                await Task.Delay(50); // Allow UI to handle events loop
                if (BaseViewModel != null)
                    await BaseViewModel.OnPageAppearing();
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Task.Run(async () =>
            {
                await Task.Delay(50); // Allow UI to handle events loop
                if (BaseViewModel != null)
                    await BaseViewModel.OnPageDissapearing();
            });
        }

    }
}
