using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBM.Model
{
    public class Login : INotifyPropertyChanged, IDataErrorInfo
    {
        private string username = "IamAkshay";

        public string Username
        {
            get { return username; }
            set { username = value; OnPropertyChanged(Username); }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged(Password); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

        public string error;

        public string Error
        {
            get { return error; }
            set
            {
                if (error != value)
                    error = value;
            }
        }

        public string this[string columnName]
        {
            get
            {
                string result = string.Empty;

                switch(columnName)
                {
                    case "Username" :
                        {
                            if (string.IsNullOrEmpty(Username))
                                result = "Required..!";

                            break;
                        }
                    case "Password":
                        {
                            if (string.IsNullOrEmpty(Password))
                                result = "Required..!";

                            break;
                        }
                }

                return result;
            }
        }
    }
}