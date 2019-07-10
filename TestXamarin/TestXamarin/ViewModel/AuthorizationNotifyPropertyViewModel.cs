using System.ComponentModel;
using System.Windows.Input;
using TestXamarin.Repositories.Users;
using Xamarin.Forms;

namespace TestXamarin.ViewModel
{
    public class AuthorizationNotifyPropertyViewModel : INotifyPropertyChanged
    {
        private string _login;
        private string _password;

        public string Login
        {
            get => _login;
            set
            {
                if (_login != value)
                {
                    _login = value;
                    OnPropertyChanged(nameof(Login));
                }
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }

        private UsersRepositories _usersRepositories;

        public ICommand AuthorizationCommand { get; }

        public AuthorizationNotifyPropertyViewModel()
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

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
