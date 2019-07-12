using Rg.Plugins.Popup.Services;
using TestXamarin.Custom.Popups;
using TestXamarin.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestXamarin.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NotesPage : BasePage
	{
		public NotesPage ()
		{
			InitializeComponent ();
		}

        private void NoteSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;
            ((ListView)sender).SelectedItem = null;
        }

        private void ShowNote(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is Note note)
                PopupNavigation.Instance.PushAsync(new NotePopup(note));
            //throw new System.NotImplementedException();
        }
    }
}