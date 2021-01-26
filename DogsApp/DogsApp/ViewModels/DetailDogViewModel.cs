using DogsApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DogsApp.ViewModels
{
    class DetailDogViewModel : GeneralViewModel
    {
        private INavigation NavigationService;

        public DetailDogViewModel(INavigation navigationService, Dogs selectedDog)
        {
            NavigationService = navigationService;
            SelectedDog = selectedDog;
            MyTitre = $"Dog : { selectedDog.Name}";
        }

        private Dogs selectedDog;

        public Dogs SelectedDog
        {
            get { return selectedDog; }
            set
            {
                selectedDog = value;
                OnPropertyChange("SelectedDog");
            }
        }
    }
}
