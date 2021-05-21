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
using System.Configuration;
using System.Data.SqlClient;
using HBM.View;

namespace HBM
{
    /// <summary>
    /// Interaction logic for gDashboard.xaml
    /// </summary>
    public partial class gDashboard : Window
    {
        List<Room> data;
        public gDashboard()
        {
            InitializeComponent();

            data = new List<Room>();
            GetData();
        }

        void GetData()
        {
            SqlConnection conn;
            SqlCommand comm;

            try
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQL_Conn"].ConnectionString);

                comm = new SqlCommand("SELECT * FROM TBL_ROOM",conn);
                comm.CommandType = System.Data.CommandType.Text;
                conn.Open();

                var res = comm.ExecuteReader();
                if(res.HasRows)
                {
                    while(res.Read())
                    {
                        Room o = new Room();
                        o.Description = res.GetString(3);
                        o.Price = res.GetDouble(2);

                        data.Add(o);
                    }
                    IC_List.ItemsSource = data;
                }
            }
            catch (SqlException ex) { ex.ToString(); }
        }

        private void tbLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginView o = new LoginView();
            this.Close();
            o.Show();
        }
    }

    class Room
    {
        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private double price;

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

    }
}