using HBM.Command;
using HBM.Model;
using HBM.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HBM.ViewModel
{
    class RegisterViewModel : INotifyPropertyChanged
    {
        private Register register;

        public Register Register
        {
            get { return register; }
            set { register = value; OnPropertyChanged("Register"); }
        }

        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }

        public RegisterViewModel()
        {
            Register = new Register();
            saveCommand = new RelayCommand(Save);
        }

        #region Save

        private RelayCommand saveCommand;

        public RelayCommand SaveCommand
        {
            get { return saveCommand; }
        }

        void Save(object param)
        {
            string Password = string.Empty;

            BusinessLayer o = new BusinessLayer();
            if (o.Register(Register, out Password))
            {
                //Message = string.Format("Welcome {0}..Your Password is {1}", Register.Username, Password);
                MessageBox.Show(string.Format("Welcome {0}..Your Password is {1}", Register.Username, Password));

                LoginView o1 = new LoginView();
                o1.ShowActivated = true;
                App.Current.Windows[0].Close();
                o1.Show();
            }
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string ProperyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(ProperyName));
        }
    }
}