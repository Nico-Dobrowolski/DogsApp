using DogsApp.DataAccessLayer;
using DogsApp.Models;
using DogsApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DogsApp.ViewModels
{
    class HomeViewModel : GeneralViewModel
    {
        #region OnLoad
        private INavigation NavigationService;
        public HomeViewModel(INavigation navigationService)
        {
            NavigationService = navigationService;
            SelectionCommand = new Command(SelectionCommandExecute);
            MyTitre = $"All Dogs";
            loadDogs();
        }


        #endregion
        //------------------------------------
        #region searchbar & filter
        private string search;
        public string Search
        {
            get { return search; }
            set
            {
                search = value;
                OnPropertyChange("Search");
                FilterDogs();
            }
        }

        #endregion

        #region Dogs

        private List<Dogs> dogs;

        public List<Dogs> Dogs
        {
            get { return dogs; }
            set
            {
                dogs = value;
                OnPropertyChange("Dogs");
            }
        }

        private List<String> listBreedGroup;

        public List<String> ListBreedGroup
        {
            get { return listBreedGroup; }
            set
            {
                listBreedGroup = value;
                OnPropertyChange("ListBreedGroup");

            }
        }

        private string selectedBreedGroup;
        public string SelectedBreedGroup
        {
            get { return selectedBreedGroup; }
            set
            {
                selectedBreedGroup = value;
                OnPropertyChange("SelectedBreedGroup");
                FilterDogs();
            }
        }

        private Dogs selectedDog;
        public Dogs SelectedDog
        {
            get { return selectedDog; }
            set
            {
                selectedDog = value;


            }
        }



        private List<Dogs> initDogs;
        private void loadDogs()
        {
   
            Task.Factory.StartNew(async () =>
            {
                DogsAPI api = new DogsAPI();
                var result = await api.GetDogsAsync();
                initDogs = result;
                ListBreedGroup = initDogs.Select(x => x.BreedGroup).Distinct().OrderBy(x => x).ToList();
                FilterDogs();

            });

        }
        #endregion

        #region Filter
        private void FilterDogs()
        {
 
            if (!String.IsNullOrWhiteSpace(Search) && !String.IsNullOrWhiteSpace(SelectedBreedGroup))
            {
                Dogs = initDogs.Where(x => x.Name.ToLower().Contains(Search.ToLower()) && x.BreedGroup == SelectedBreedGroup).ToList();
            }
            else if (String.IsNullOrWhiteSpace(Search) && !String.IsNullOrWhiteSpace(SelectedBreedGroup))
            {
                Dogs = initDogs.Where(x => x.BreedGroup == SelectedBreedGroup).ToList();
            }
            else if (!String.IsNullOrWhiteSpace(Search) && String.IsNullOrWhiteSpace(SelectedBreedGroup))
            {

                Dogs = initDogs.Where(x => x.Name.ToLower().Contains(Search.ToLower())).ToList();
            }
            else
            {
                Dogs = initDogs;
            }
 
        }
        #endregion
        #region ICommand
        public ICommand SelectionCommand { get; }
        private void SelectionCommandExecute()
        {

            NavigationService.PushAsync(new DetailDog(SelectedDog));

        }
        #endregion
    }
}
