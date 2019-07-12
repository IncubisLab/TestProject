using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using TestXamarin.IoC;
using TestXamarin.Models;
using TestXamarin.Repositories.Notes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestXamarin.Custom.Popups
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NotePopup : PopupPage
	{

        private readonly INotesRepository _notesRepository;

        public NotePopup ()
		{
			InitializeComponent ();
            _notesRepository = Locator.Resolve<INotesRepository>();
        }

        public NotePopup(Note note) : this()
        {
            title.Text = note.Title;
            message.Text = note.Message;
        }

        public Action<object> OnUpdateNotes;

        private void SaveClicked(object sender, EventArgs e)
        {
            if (Application.Current.Properties.TryGetValue("userId", out var userId))
            {
                var note = new Note
                {
                    Id = Guid.NewGuid(),
                    Title = title.Text,
                    Message = message.Text,
                    UserId = Guid.Parse(userId.ToString()),
                    DateTime = DateTime.Now
                };
              var result = _notesRepository.CreateNote(note);

              if (result)
              {
                  OnUpdateNotes?.Invoke(this);
                  DisplayAlert("Сообщение", "Заметка создана", "Ок");
              }
              else
                    DisplayAlert("Ошибка", "Ошибка создание заметки", "Ok");
                PopupNavigation.Instance.PopAsync();
            }
        }

        private void CancelClicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PopAsync();
        }
    }
}