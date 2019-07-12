using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TestXamarin.Custom.Popups;
using TestXamarin.Models;
using TestXamarin.Repositories.Notes;
using Xamarin.Forms;

namespace TestXamarin.ViewModels
{
    public class NotesViewModel : BaseViewModel
    {
        private ObservableCollection<Note> _notes;

        private bool _isBusy;
        private bool _isRefreshing;

        private readonly INotesRepository _notesRepository;

        public ObservableCollection<Note> Notes
        {
            get => _notes;
            set => SetProperty(ref _notes, value);
        }

        private bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => SetProperty(ref _isRefreshing, value);
        }

        public ICommand CreateNoteCommand { get; }
        public ICommand ClearNoteCommand { get; }
        public ICommand RefreshNotesCommand { get; }

        public ICommand UpdateNoteCommand { get; }

        private Guid _userId;

        public NotesViewModel(INotesRepository notesRepository)
        {
            _notesRepository = notesRepository ?? throw new ArgumentNullException(nameof(notesRepository));
            CreateNoteCommand = new Command(CreateNote);
            ClearNoteCommand = new Command(ClearNote);
            RefreshNotesCommand = new Command(RefreshNotes);
            UpdateNoteCommand = new Command(RefreshNotes);
            if (Application.Current.Properties.TryGetValue("userId", out var userId))
            {
                _userId = Guid.Parse(userId.ToString());
                Notes = new ObservableCollection<Note>(_notesRepository.GetNotes(_userId));
            }
        }

        private void CreateNote()
        {
            var notePopup = new NotePopup();
            notePopup.OnUpdateNotes += OnUpdateNotes;
            ShowPopup(notePopup);
        }

        private void OnUpdateNotes(object arg) => RefreshNotes();

        private void RefreshNotes()
        {
            if (IsBusy) return;
            IsBusy = true;
            IsRefreshing = true;

            Notes = new ObservableCollection<Note>(_notesRepository.GetNotes(_userId));

            IsRefreshing = false;
            IsBusy = false;
        }

        private void ClearNote()
        {
            var result = _notesRepository.Clear();
            if (result)
            {
                RefreshNotes();
                ShowAlert("Сообщение", "Заметки удалены", "Ok");
            }
            else
            {
                ShowAlert("Ошибка", "Ошибка удаления заметок", "Ok");
            }
        }


    }
}
