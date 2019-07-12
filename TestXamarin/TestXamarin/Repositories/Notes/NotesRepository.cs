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
                Db.BeginTransaction();
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

        /// <summary>
        /// Удаление заметки
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        public bool Remove(Note note)
        {
            try
            {
                Db.RunInTransaction(() => { Db.Delete<Note>(note); });
                return true;
            }
            catch (Exception ex)
            {
                Db.Rollback();
                return false;
            }
        }

        /// <summary>
        /// Очистка всех заметок
        /// </summary>
        /// <returns></returns>
        public bool Clear()
        {
            try
            {
                Db.RunInTransaction(() =>
                {
                    Db.DeleteAll<Note>();
                });

                return true;
            }
            catch (Exception ex)
            {
                Db.Rollback();
                return false;
            }
        }
    }
}
