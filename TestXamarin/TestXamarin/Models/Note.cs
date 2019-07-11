using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace TestXamarin.Models
{
    [Table(nameof(Note))]
    public class Note
    {
        [PrimaryKey]
        public Guid Id { get; set; }

        public string Title { get; set; }

        public Guid UserId { get; set; }

        public DateTime DateTime { get; set; }

        public string Message { get; set; }
    }
}
