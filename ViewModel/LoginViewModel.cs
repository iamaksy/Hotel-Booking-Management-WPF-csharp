using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using HBM.Model;
using System.Windows.Input;
using HBM.Command;
using HBM.View;
using System.Windows;

namespace HBM.ViewModel
{
    class LoginViewModel : INotifyPropertyChanged
    {
        private Login loginCurrent;

        public Login LoginCurrent
        {
            get { return loginCurrent; }
            set { loginCurrent = value; OnPropertyChanged("LoginCurrent"); }
        }

        public LoginViewModel()
        {
            LoginCurrent = new Login();
            loginCommand = new RelayCommand(LoginUser);
        }

        private RelayCommand loginCommand;

        public RelayCommand LoginCommand
        {
            get { return loginCommand; }
        }

        void LoginUser(object param)
        {
            BusinessLayer o = new BusinessLayer();
            if (o.Login(LoginCurrent))
            {
                App.Current.Properties["LoginUserName"] = LoginCurrent.Username;
                DashboardViewModel o2 = new DashboardViewModel(LoginCurrent.Username);

                DashboardView o1 = new DashboardView();
                o1.ShowActivated = true;
                App.Current.MainWindow.Close();
                o1.DataContext = o2;
                o1.Show();
            }
            LoginCurrent = new Login();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}