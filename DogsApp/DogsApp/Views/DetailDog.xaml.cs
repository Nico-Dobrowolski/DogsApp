using DogsApp.Models;
using DogsApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DogsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailDog : ContentPage
    {
        public DetailDog(Dogs SelectedDog)
        {
            InitializeComponent();
            BindingContext = new DetailDogViewModel(Navigation, SelectedDog);
        }
    }
}