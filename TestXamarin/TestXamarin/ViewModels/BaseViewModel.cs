using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using TestXamarin.IoC;
using TestXamarin.Services.Navigation;
using Xamarin.Forms;

namespace TestXamarin.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        #region Private Fields

        private bool _isBusy;

        #endregion

        #region Protected fields

        protected readonly INavigationService Navigation;

        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        #endregion

       

        public BaseViewModel()
        {
            Navigation = Locator.Resolve<INavigationService>();
        }

        public virtual Task OnPageAppearing()
        {
            return Task.FromResult(0);
        }

        public virtual Task OnPageDissapearing()
        {
            return Task.FromResult(0);
        }

        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }

        protected void ShowPopup<T>(T popupPage) where T : PopupPage
        {
            Device.BeginInvokeOnMainThread(async () => await PopupNavigation.Instance.PushAsync(popupPage));
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T field, T value,
            [CallerMemberName] string propertyName = "", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void SetObservableProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return;
            field = value;
            OnPropertyChanged(propertyName);
        }

        /// <summary>
        /// Показать окно сообщения
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="cancel"></param>
        protected void ShowAlert(string title, string message, string cancel)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                try
                {
                    await Application.Current.MainPage.DisplayAlert(title, message, cancel);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            });
        }
    }
}
