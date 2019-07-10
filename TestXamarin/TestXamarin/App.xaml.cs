using System;
using TestXamarin.Page;
using TestXamarin.Repositories.Users;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TestXamarin
{
    public partial class App : Application
    {
        private UsersRepositories _usersRepositories;

        public App()
        {
            InitializeComponent();
            _usersRepositories = new UsersRepositories();
            MainPage = new NavigationPage(new AuthorizationPage(_usersRepositories));
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
