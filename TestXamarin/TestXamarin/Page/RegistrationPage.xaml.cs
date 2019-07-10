using TestXamarin.Repositories.Users;
using TestXamarin.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestXamarin.Page
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegistrationPage : ContentPage
    {
        private readonly UsersRepositories _usersRepositories;

		public RegistrationPage (UsersRepositories usersRepositories)
        {
            _usersRepositories = usersRepositories;
			InitializeComponent ();
            BindingContext = new RegistrationViewModel(_usersRepositories);
        }
	}
}