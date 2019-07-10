using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestXamarin.Repositories.Users;
using TestXamarin.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestXamarin.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthorizationPage : ContentPage
    {
        private readonly UsersRepositories _usersRepositories;

        public AuthorizationPage(UsersRepositories usersRepositories)
        {
            InitializeComponent();
            _usersRepositories = usersRepositories;
            BindingContext = new AuthorizationViewModel(_usersRepositories);
        }

        private async void RegistrationClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage(_usersRepositories));
        }
    }
}