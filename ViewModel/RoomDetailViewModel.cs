using HBM.Command;
using HBM.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBM.ViewModel
{
    public class RoomDetailViewModel : INotifyPropertyChanged
    {
        public RoomDetailViewModel()
        {
            CurrentRoom = new RoomDetail();
            LoadRoomData();
        }

        public RoomDetailViewModel(string RoomCode)
        {
            CurrentRoom = new RoomDetail();
            LoadRoomData(RoomCode);
        }

        private RoomDetail roomDetail;

        public RoomDetail CurrentRoom
        {
            get { return roomDetail; }
            set { roomDetail = value; OnPropertyChanged("CurrentRoom"); }
        }

        void LoadRoomData()
        {
            BusinessLayer o = new BusinessLayer();
            CurrentRoom = o.GetRoom("RM001");
        }

        void LoadRoomData(string RoomCode)
        {
            BusinessLayer o = new BusinessLayer();
            CurrentRoom = o.GetRoom(RoomCode);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}