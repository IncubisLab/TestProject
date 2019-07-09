using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestXamarin.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestXamarin.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthorizationPage : ContentPage
    {
        public AuthorizationPage()
        {
            InitializeComponent();
            BindingContext = new AuthorizationViewModel();
        }

        private void AuthorizationClicked(object sender, EventArgs e)
        {
            DisplayAlert("Сообщение", "Авторизация пользователя", "Ок");
        }
    }
}