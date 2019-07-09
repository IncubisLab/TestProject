using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TestXamarin.Repositories.Users;
using Xamarin.Forms;

namespace TestXamarin.ViewModel
{
    public class AuthorizationViewModel
    {
        public string Login { get; set; }

        public string Password { get; set; }

        private UsersRepositories _usersRepositories;

        public ICommand AuthorizationCommand { get; }

        public AuthorizationViewModel()
        {
            AuthorizationCommand = new Command(AuthorizationUser);
            _usersRepositories = new UsersRepositories();
        }

        private void AuthorizationUser()
        {
          var user = _usersRepositories.GetUser(Login, Password);
        }
    }
}
