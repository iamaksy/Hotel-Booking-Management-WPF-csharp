using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace HBM.Model
{
    public class Dashboard : INotifyPropertyChanged
    {
        private string roomCode;

        public string RoomCode
        {
            get { return roomCode; }
            set { roomCode = value; OnPropertyChanged("RoomCode"); }
        }

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

        private double price;

        public double Price
        {
            get { return price; }
            set { price = value; OnPropertyChanged("Price"); }
        }

        private double dPrice;

        public double DPrice
        {
            get { return dPrice; }
            set { dPrice = value; OnPropertyChanged("DPrice"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}