using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HBM.Model
{
    public class Register : INotifyPropertyChanged,IDataErrorInfo
    {
        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; OnPropertyChanged("Username"); }
        }

        private bool isAdmin;

        public bool IsAdmin
        {
            get { return isAdmin; }
            set { isAdmin = value; OnPropertyChanged("IsAdmin"); }
        }

        private long contact1;

        public long Contact1
        {
            get { return contact1; }
            set { contact1 = value; OnPropertyChanged("Contact1"); }
        }

        private long contact2;

        public long Contact2
        {
            get { return contact2; }
            set { contact2 = value; OnPropertyChanged("Contact2"); }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChanged("Email"); }
        }

        private string location;

        public string Location
        {
            get { return location; }
            set { location = value; OnPropertyChanged("Location"); }
        }

        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; OnPropertyChanged("Adress"); }
        }

        private int pinCode;

        public int PinCode
        {
            get { return pinCode; }
            set { pinCode = value; OnPropertyChanged("PinCode"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string ProperyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(ProperyName));
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

                switch (columnName)
                {
                    case "Username":
                        {
                            if (string.IsNullOrEmpty(Username))
                                result = "Required..!";

                            break;
                        }
                    case "Contact1":
                        {
                            if (string.IsNullOrEmpty(Contact1.ToString()))
                                result = "Required..!";
                            else if (Contact1.ToString().Length != 10)
                                result += "Invalid Format..!";

                            break;
                        }
                    case "Contact2":
                        {
                            if (string.IsNullOrEmpty(Contact2.ToString()))
                                result = "Required..!";
                            else if (Contact2.ToString().Length != 10)
                                result += "Invalid Format..!";

                            break;
                        }
                    case "Email":
                        {
                            string MatchEmailPattern = "^(([\\w-]+\\.)+[\\w-]+|([a-zA-Z]{1}|[\\w-]{2,}))@" + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				                                [0-9]{1,2}|25[0-5]|2[0-4][0-9])\." + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				                                [0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|" + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";

                            if (string.IsNullOrEmpty(Email))
                                result = "Required..!";
                            else if (!Regex.IsMatch(Email, MatchEmailPattern))
                                result += "Invalid Email Format!!!";

                            break;
                        }
                    case "Location":
                        {
                            if (string.IsNullOrEmpty(Location))
                                result = "Required..!";

                            break;
                        }
                    case "PinCode":
                        {
                            if (string.IsNullOrEmpty(PinCode.ToString()))
                                result = "Required..!";
                            else if (Contact2.ToString().Length != 6)
                                result += "Invalid Format..!";

                            break;
                        }
                }

                return result;
            }
        }
    }
}