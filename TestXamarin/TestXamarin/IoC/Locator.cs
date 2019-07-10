using System;
using Autofac;
using TestXamarin.Page;
using TestXamarin.Repositories.Users;
using TestXamarin.ViewModel;

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
            
            #region Pages

            builder.RegisterType<AuthorizationPage>();
            builder.RegisterType<RegistrationPage>();
            builder.RegisterType<MainPage>();

            #endregion

            #region ViewModels

            builder.RegisterType<AuthorizationViewModel>();
            builder.RegisterType<RegistrationViewModel>();

            #endregion

            #region Repositories

            builder.RegisterType<UsersRepository>().As<IUsersRepository>().SingleInstance();

            #endregion
        }

        #endregion
    }
}
