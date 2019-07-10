using System;
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

        private readonly IUsersRepository _usersRepository;

        public ICommand AuthorizationCommand { get; }
       

        public AuthorizationViewModel(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
            AuthorizationCommand = new Command(AuthorizationUser);
        }

        private void AuthorizationUser()
        {
            var user = _usersRepository.GetUser(Login, Password);
            ShowAlert("Сообщение", "Логин: " + user.Login + "\nИмя: " + user.Name + "\nФамилия: " + user.LastName, "Ок");
        }

    }
}
