using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace HBM.Model
{
    public class Booking : INotifyPropertyChanged
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

        private string desc;

        public string Desc
        {
            get { return desc; }
            set { desc = value; OnPropertyChanged("Desc"); }
        }

        private DateTime checkIN = DateTime.Now;

        public DateTime CheckIN
        {
            get { return checkIN; }
            set { checkIN = value; OnPropertyChanged("CheckIN"); }
        }

        private DateTime checkOut = DateTime.Now.AddDays(1);

        public DateTime ChecckOut
        {
            get { return checkOut; }
            set { checkOut = value; OnPropertyChanged("ChecckOut"); }
        }

        private string totalDay = "1 Nights 2 Days";

        public string TotalDay
        {
            get { return totalDay; }
            set { totalDay = value; OnPropertyChanged("TotalDay"); }
        }

        private double roomPrice;

        public double RoomPrice
        {
            get { return roomPrice; }
            set { roomPrice = value; OnPropertyChanged("RoomPrice"); }
        }

        private double price;

        public double Price
        {
            get { return price; }
            set { price = value; OnPropertyChanged("price"); }
        }

        private double gst;

        public double GST
        {
            get { return gst; }
            set { gst = value; OnPropertyChanged("GST"); }
        }

        private double tax;

        public double TAX
        {
            get { return tax; }
            set { tax = value; OnPropertyChanged("tax"); }
        }

        private double total;

        public double Total
        {
            get { return total; }
            set { total = value; OnPropertyChanged("Total"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}