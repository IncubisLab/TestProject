using TestXamarin.IoC;
using TestXamarin.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TestXamarin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var authorizationPage = Locator.Resolve<AuthorizationPage>();
            MainPage = new NavigationPage(authorizationPage);
            //MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
