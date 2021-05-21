using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using HBM.Model;
using HBM.Command;
using System.Windows;

namespace HBM.ViewModel
{
    class BookingViewModel : INotifyPropertyChanged
    {
        private Booking booking;

        public Booking Booking_
        {
            get { return booking; }
            set { booking = value; OnPropertyChanged("Booking_"); }
        }

        public BookingViewModel()
        {
            Booking_ = new Booking();
            bookCommand = new RelayCommand(BookRoom);

            //LoadBookingDetails();
        }

        public BookingViewModel(string RoomCode)
        {
            Booking_ = new Booking();
            bookCommand = new RelayCommand(BookRoom);
            fairCommand = new RelayCommand(GetFair);

            LoadBookingDetails(RoomCode);
        }

        private RelayCommand bookCommand;

        public RelayCommand BookCommand
        {
            get { return bookCommand; }
        }

        private RelayCommand fairCommand;

        public RelayCommand FairCommand
        {
            get { return fairCommand; }
        }

        void GetFair(object i)
        {
            string data = Booking_.TotalDay.Substring(0, 2);

            int totalDays = Convert.ToInt32(data);

            booking.Price = (booking.RoomPrice * totalDays);
            booking.Price += (Booking_.Price) * (0.08);
            booking.Price += booking.TAX;

            Booking_.GST = (Booking_.RoomPrice * totalDays) * (0.08);
        }

        void BookRoom(object i)
        {
            string data = Booking_.TotalDay.Substring(0, 2);
            int totalDays = Convert.ToInt32(data);

            string UserName = App.Current.Properties["LoginUserName"].ToString();

            BusinessLayer o = new BusinessLayer();
            o.BookRoom(Booking_, totalDays, UserName);
        }

        void LoadBookingDetails(string RoomCode)
        {
            BusinessLayer o = new BusinessLayer();
            Booking_ = o.LoadBookingData(RoomCode);

            booking.Price = booking.RoomPrice;
            booking.Price += (Booking_.RoomPrice) * (0.08);
            booking.Price += booking.TAX;

            Booking_.GST = (Booking_.RoomPrice) * (0.08);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
