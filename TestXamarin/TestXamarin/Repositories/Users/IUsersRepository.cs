using System;
using System.Collections.Generic;
using System.Text;
using TestXamarin.Models;

namespace TestXamarin.Repositories.Users
{
    public interface IUsersRepository
    {

        /// <summary>
        /// Получения пользователя
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        User GetUser(string login, string password);

        /// <summary>
        /// Сохранения пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool CreateUser(User user);

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool DeleteUser(User user);
    }
}
