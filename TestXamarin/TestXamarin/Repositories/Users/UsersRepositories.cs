using System;
using System.Collections.Generic;
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


        public void CreatUser()
        {

        }


        public void DeleteUser()
        {

        }
    }
}
