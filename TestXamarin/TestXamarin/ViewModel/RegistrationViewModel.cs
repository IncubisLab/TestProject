using System;
using System.Windows.Input;
using TestXamarin.Models;
using TestXamarin.Repositories.Users;
using Xamarin.Forms;

namespace TestXamarin.ViewModel
{
    public class RegistrationViewModel : BaseViewModel
    {
        private string _login;
        private string _name;
        private string _lastName;
        private string _password;

        private readonly IUsersRepository _usersRepository;

        public string Login
        {
            get => _login;
            set => SetProperty(ref _login, value);
        }

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public string LastName
        {
            get => _lastName;
            set => SetProperty(ref _lastName, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }


        public ICommand RegistrationCommand { get; }

        public RegistrationViewModel(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
            RegistrationCommand = new Command(RegistrationUser);
        }

        private void RegistrationUser()
        {
            User user = new User
            {
                Id = Guid.NewGuid(),
                Login = this.Login,
                Name = this.Name,
                LastName = this.LastName,
                Password = this.Password
            };
           var result = _usersRepository.CreateUser(user);

            if (result)
                ShowAlert("Сообщение", "Пользователь успешно создан!","Ок");
            else
                ShowAlert("Ошибка", "Ошибка создания пользователя!", "Ок");
        }
    }
}
