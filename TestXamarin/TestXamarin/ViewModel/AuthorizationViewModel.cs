using System.Windows.Input;
using TestXamarin.Repositories.Users;
using Xamarin.Forms;

namespace TestXamarin.ViewModel
{
    public class AuthorizationViewModel : BaseViewModel
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

        private readonly UsersRepositories _usersRepositories;

        public ICommand AuthorizationCommand { get; }
       

        public AuthorizationViewModel(UsersRepositories usersRepositories)
        {
            AuthorizationCommand = new Command(AuthorizationUser);
            _usersRepositories = usersRepositories;
        }

        private void AuthorizationUser()
        {
            var user = _usersRepositories.GetUser(Login, Password);
            ShowAlert("Сообщение", "Логин: " + user.Login + "\nИмя: " + user.Name + "\nФамилия: " + user.LastName, "Ок");
        }

    }
}
