using System;
using TestXamarin.Repositories.Users;
using TestXamarin.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestXamarin.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthorizationPage : ContentPage
    {
        private readonly IUsersRepository _usersRepository;

        public AuthorizationPage(IUsersRepository usersRepository)
        {
            InitializeComponent();
            _usersRepository = usersRepository;
            BindingContext = new AuthorizationViewModel(_usersRepository);
        }

        private async void RegistrationClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage(_usersRepository));
        }
    }
}