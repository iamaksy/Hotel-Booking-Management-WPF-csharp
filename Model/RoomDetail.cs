using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBM.Model
{
    public class RoomDetail : INotifyPropertyChanged
    {
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; OnPropertyChanged("Title"); }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; OnPropertyChanged("Description"); }
        }

        private bool television;

        public bool Television
        {
            get { return television; }
            set { television = value; OnPropertyChanged("Television"); }
        }

        private bool wiFi;

        public bool WiFi
        {
            get { return wiFi; }
            set { wiFi = value; OnPropertyChanged("WiFi"); }
        }

        private bool outDoorGames;

        public bool OutDoorGames
        {
            get { return outDoorGames; }
            set { outDoorGames = value; OnPropertyChanged("OutDoorGames"); }
        }

        private bool breakfast;

        public bool Breakfast
        {
            get { return breakfast; }
            set { breakfast = value; OnPropertyChanged("Breakfast"); }
        }

        private bool lunch;

        public bool Lunch
        {
            get { return lunch; }
            set { lunch = value; OnPropertyChanged("Lunch"); }
        }

        private string bedType;

        public string BedType
        {
            get { return bedType; }
            set { bedType = value; OnPropertyChanged("BedType"); }
        }

        private string aminity_1;

        public string Aminity_1
        {
            get { return aminity_1; }
            set { aminity_1 = value; OnPropertyChanged("Aminity_1"); }
        }

        private string aminity_2;

        public string Aminity_2
        {
            get { return aminity_2; }
            set { aminity_2 = value; OnPropertyChanged("Aminity_2"); }
        }

        private bool luggage;

        public bool Luggage
        {
            get { return luggage; }
            set { luggage = value; OnPropertyChanged("Luggage"); }
        }

        private bool bellBoy;

        public bool BellBoy
        {
            get { return bellBoy; }
            set { bellBoy = value; OnPropertyChanged("BellBoy"); }
        }

        private string aminity_3;

        public string Aminity_3
        {
            get { return aminity_3; }
            set { aminity_3 = value; OnPropertyChanged("Aminity_3"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}