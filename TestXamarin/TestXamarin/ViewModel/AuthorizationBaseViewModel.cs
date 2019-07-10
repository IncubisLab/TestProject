using System.Windows.Input;
using TestXamarin.Repositories.Users;
using Xamarin.Forms;

namespace TestXamarin.ViewModel
{
    public class AuthorizationBaseViewModel : BaseViewModel
    {
        private string _login;
        private string _password;

        public string Login
        {
            get => _login;
            set => SetProperty(ref _login, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        private UsersRepositories _usersRepositories;

        public ICommand AuthorizationCommand { get; }

        public AuthorizationBaseViewModel()
        {
            AuthorizationCommand = new Command(AuthorizationUser);
            _usersRepositories = new UsersRepositories();
        }

        private void AuthorizationUser()
        {
            //var user = _usersRepositories.GetUser(Login, Password);
            Login = "AndreySh";
            Password = "456789";
        }

    }
}
