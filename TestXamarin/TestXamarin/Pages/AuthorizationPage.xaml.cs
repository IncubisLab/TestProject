using System;
using TestXamarin.Repositories.Users;
using TestXamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestXamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthorizationPage : BasePage
    {

        public AuthorizationPage(IUsersRepository usersRepository)
        {
            InitializeComponent();
            BindingContext = new AuthorizationViewModel(usersRepository);
        }
    }
}