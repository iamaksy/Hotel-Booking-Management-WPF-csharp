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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HBM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<Data> list = new List<Data>()
            {
                new Data(){Name="Akshay",LastName="Ghadi"},
                new Data(){Name="Sanket",LastName="Keny"},
                new Data(){Name="Poonam",LastName="Desai"}
            };

            IC_List.ItemsSource = list;
        }
    }

    class Data
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
    }
}
