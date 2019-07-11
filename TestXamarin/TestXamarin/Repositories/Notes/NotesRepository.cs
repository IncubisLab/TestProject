using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using TestXamarin.IoC;
using TestXamarin.Models;
using Xamarin.Forms;

namespace TestXamarin.Repositories.Notes
{
    public class NotesRepository: INotesRepository
    {

        private SQLiteConnection Db { get; }

        public NotesRepository()
        {
            Db = new SQLiteConnection(System.IO.Path.Combine(DependencyService.Get<ISQLiteFolderProvide>().SqLiteProvide, "appDB"));
            Db.CreateTable<Note>();
        }

        /// <summary>
        /// Создание заметки
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        public bool CreateNote(Note note)
        {
            try
            {
                Db.Commit();
                Db.Insert(note);
                Db.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Db.Rollback();
                return false;
            }
        }

        public IList<Note> GetNotes(Guid userId)
            => Db.Table<Note>().Where(notes => notes.UserId == userId).ToList();
    }
}
