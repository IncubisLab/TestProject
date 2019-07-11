using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using TestXamarin.Models;
using TestXamarin.Repositories.Notes;
using Xamarin.Forms;

namespace TestXamarin.ViewModels
{
    public class NotesViewModel : BaseViewModel
    {
        private ObservableCollection<Note> _notes;

        private readonly INotesRepository _notesRepository;

        public ObservableCollection<Note> Notes
        {
            get => _notes;
            set => SetProperty(ref _notes, value);
        }

        public ICommand CreateNoteCommand { get; }

        private Guid _userId;

        public NotesViewModel(INotesRepository notesRepository)
        {
            _notesRepository = notesRepository ?? throw new ArgumentNullException(nameof(notesRepository));
           
            CreateNoteCommand = new Command(CreateNote);
        }

        private void CreateNote()
        {
            var note = new Note
            {
                Id = Guid.NewGuid(),
                Title = "Заметка",
                Message = "Новая заметка",
                UserId = _userId
            };

           var result = _notesRepository.CreateNote(note);
           if (result)
               ShowAlert("Сообщение", "Заметка создана", "Ok");
           else 
               ShowAlert("Ошибка","Ошибка создание заметки", "Ok");
        }

        public override Task InitializeAsync(object parametr)
        {
            if (parametr is User user)
            {
                _userId = user.Id;
            }

            Notes = new ObservableCollection<Note>(_notesRepository.GetNotes(_userId));

            return Task.FromResult(false);
        }
    }
}
