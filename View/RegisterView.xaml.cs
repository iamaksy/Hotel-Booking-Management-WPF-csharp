using HBM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HBM
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class RegisterView : Window
    {
        public RegisterView()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginView o = new LoginView();
            this.Hide();
            o.Show();
        }

        //private void btnRegister_Click(object sender, RoutedEventArgs e)
        //{
        //    string Password = string.Empty;

        //    BusinessLayer o = new BusinessLayer();
        //    if (o.Register(this.Username.Text, false, Convert.ToInt64(this.Cont1.Text), Convert.ToInt64(this.Cont2.Text), this.Email.Text, this.Loc.Text, string.Empty, Convert.ToInt32(this.Pincode.Text), out Password))
        //        MessageBox.Show("Password Generated : " + Password);
        //}
    }
}