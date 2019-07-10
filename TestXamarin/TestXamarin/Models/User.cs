using System;
using SQLite;

namespace TestXamarin.Models
{
    [Table(nameof(User))]
    public class User
    {
        [PrimaryKey]
        public Guid Id { get; set; }
   
        public string Name { get; set; }

        public string LastName { get; set; }

        [Unique]
        public string Login { get; set; }

        public string Password { get; set; }
    }
}
