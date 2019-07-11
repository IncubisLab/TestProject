using System;
using Autofac;
using TestXamarin.Pages;
using TestXamarin.Repositories.Notes;
using TestXamarin.Repositories.Users;
using TestXamarin.Services.Navigation;
using TestXamarin.ViewModels;

namespace TestXamarin.IoC
{
    public class Locator
    {
        private static readonly IContainer _container;

        static Locator()
        {
            var builder = new ContainerBuilder();

            ConfigureContainer(builder);

            _container = builder.Build();
        }

        public static T Resolve<T>() where T : class
        {
            return _container.Resolve<T>();
        }

        public static object Resolve(Type type)
        {
            return _container.Resolve(type);
        }

        #region Registrations

        private static void ConfigureContainer(ContainerBuilder builder)
        {

            #region Services

            builder.RegisterType<NavigationService>().As<INavigationService>();

            #endregion


            #region Pages

            builder.RegisterType<AuthorizationPage>();
            builder.RegisterType<RegistrationPage>();
            builder.RegisterType<MainPage>();
            builder.RegisterType<NotesPage>();

            #endregion

            #region ViewModels

            builder.RegisterType<AuthorizationViewModel>();
            builder.RegisterType<RegistrationViewModel>();
            builder.RegisterType<NotesViewModel>();

            #endregion

            #region Repositories

            builder.RegisterType<UsersRepository>().As<IUsersRepository>().SingleInstance();
            builder.RegisterType<NotesRepository>().As<INotesRepository>().SingleInstance();

            #endregion
        }

        #endregion
    }
}
