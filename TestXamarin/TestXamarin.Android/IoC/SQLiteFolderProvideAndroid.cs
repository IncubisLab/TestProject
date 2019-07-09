using TestXamarin.Droid.IoC;
using TestXamarin.IoC;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteFolderProvideAndroid))]
namespace TestXamarin.Droid.IoC
{
    public class SQLiteFolderProvideAndroid: ISQLiteFolderProvide
    {
        public string SqLiteProvide => System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
    }
}