using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using HBM.Model;
using HBM.Command;
using HBM.View;
using System.Collections.ObjectModel;

namespace HBM.ViewModel
{
    public class DashboardViewModel : INotifyPropertyChanged
    {
        public DashboardViewModel()
        {
            DashboardList = new ObservableCollection<Dashboard>();

            viewCommand = new RelayCommand(View);
            bookCommand = new RelayCommand(Book);

            LoadDashboardData();
        }

        public DashboardViewModel(string _ActiveUserName)
        {
            DashboardList = new ObservableCollection<Dashboard>();

            ActiveUserName = _ActiveUserName;
            viewCommand = new RelayCommand(View);
            bookCommand = new RelayCommand(Book);

            LoadDashboardData();
        }

        private ObservableCollection<Dashboard> dashboards;

        public ObservableCollection<Dashboard> DashboardList
        {
            get { return dashboards; }
            set { dashboards = value; OnPropertyChanged("dashboards"); }
        }

        private string activeUserName;

        public string ActiveUserName
        {
            get { return activeUserName; }
            set { activeUserName = value; }
        }

        private RelayCommand viewCommand;

        public RelayCommand ViewCommand
        {
            get { return viewCommand; }
        }

        private RelayCommand bookCommand;

        public RelayCommand BookCommand
        {
            get { return bookCommand; }
        }

        void View(object i)
        {
            string RoomCode = DashboardList[(int)i].RoomCode;

            RoomDetailViewModel o1 = new RoomDetailViewModel(RoomCode);

            RoomDetailView o = new RoomDetailView();
            o.DataContext = o1;
            //o.Owner = App.Current.MainWindow;
            App.Current.MainWindow.Hide();
            o.ShowDialog();
        }

        void Book(object i)
        {
            string RoomCode = DashboardList[(int)i].RoomCode;

            BookingViewModel o1 = new BookingViewModel(RoomCode);

            BookingView o = new BookingView();
            o.DataContext = o1;
            //o.Owner = App.Current.MainWindow;
            App.Current.MainWindow.Hide();
            o.ShowDialog();
        }

        void LoadDashboardData()
        {
            BusinessLayer o = new BusinessLayer();
            DashboardList = new ObservableCollection<Dashboard>(o.GetDashBoard());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}