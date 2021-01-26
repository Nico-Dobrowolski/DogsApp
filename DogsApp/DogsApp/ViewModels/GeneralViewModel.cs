using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DogsApp.ViewModels
{
    class GeneralViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string myTitre;
        public string MyTitre
        {
            get { return myTitre; }
            set
            {
                myTitre = value;
                OnPropertyChange("MyTitre");
            }
        }


        public void OnPropertyChange(String PropertyName = null)
        {
            if (PropertyChanged == null)
            {
                return;
            }
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }


}
