using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using TestXamarin.IoC;
using TestXamarin.Models;
using Xamarin.Forms;

namespace TestXamarin.Repositories.Users
{
    public class UsersRepositories
    {
        private SQLiteConnection Db { get; }

        public UsersRepositories()
        {
            Db = new SQLiteConnection(System.IO.Path.Combine(DependencyService.Get<ISQLiteFolderProvide>().SqLiteProvide, "appDB"));
            Db.CreateTable<User>();
        }

        public User GetUser(string login, string password)
        {
            var user = Db.Table<User>().SingleOrDefault(us => us.Login == login && us.Password == password);
            return user;
        }

        /// <summary>
        /// Сохранение чека
        /// </summary>
        /// <param name="user">User</param>
        public bool CreatUser(User user)
        {
            try
            {
                Db.BeginTransaction();
                Db.Insert(user);
                Db.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Db.Rollback();
                return false;
            }
        }

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="user">User parameter</param>
        /// <returns></returns>
        public bool DeleteUser(User user)
        {
            try
            {
                Db.BeginTransaction();
                Db.Delete(user);
                Db.Commit();
                return true;
            }
            catch (Exception e)
            {
                Db.Rollback();
                return false;
            }
        }
    }
}
