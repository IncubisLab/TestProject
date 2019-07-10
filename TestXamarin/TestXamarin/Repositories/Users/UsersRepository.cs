using System;
using System.Linq;
using SQLite;
using TestXamarin.IoC;
using TestXamarin.Models;
using Xamarin.Forms;

namespace TestXamarin.Repositories.Users
{
    public class UsersRepository:IUsersRepository
    {
        private SQLiteConnection Db { get; }

        public UsersRepository()
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
        /// Сохранение пользователя
        /// </summary>
        /// <param name="user">User</param>
        public bool CreateUser(User user)
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
