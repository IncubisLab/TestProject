using System;
using System.Collections.Generic;
using TestXamarin.Models;

namespace TestXamarin.Repositories.Notes
{
    public interface INotesRepository
    {
        /// <summary>
        /// Создание заметки
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        bool CreateNote(Note note);

        /// <summary>
        /// Получения списка заметок
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <returns></returns>
        IList<Note> GetNotes(Guid userId);

        /// <summary>
        /// Удаление заметки
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        bool Remove(Note note);

        /// <summary>
        /// Удаление всех заметок
        /// </summary>
        /// <returns></returns>
        bool Clear();
    }
}
