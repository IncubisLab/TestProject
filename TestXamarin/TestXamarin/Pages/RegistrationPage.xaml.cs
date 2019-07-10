using TestXamarin.Repositories.Users;
using TestXamarin.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestXamarin.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegistrationPage : ContentPage
    {
       
		public RegistrationPage (IUsersRepository usersRepository)
        {
			InitializeComponent ();
            BindingContext = new RegistrationViewModel(usersRepository);
        }
	}
}