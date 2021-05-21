using HBM.Model;
using HBM.ViewModel;
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

namespace HBM.View
{
    /// <summary>
    /// Interaction logic for BookingView.xaml
    /// </summary>
    public partial class BookingView : Window
    {
        public BookingView()
        {
            InitializeComponent();

            DP_in.DisplayDateStart = DateTime.Today;
            DP_in.DisplayDateEnd = DateTime.Now.AddDays(10);

            DP_out.DisplayDateStart = DateTime.Today;
            DP_out.DisplayDateEnd = DateTime.Now.AddDays(15);
        }

        private void Window_Closed(object sender, EventArgs e)
        {

        }

        private void DP_in_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DP_out.IsEnabled = true;
            DP_out.SelectedDate = DP_in.SelectedDate.Value.AddDays(1);

            DP_out.DisplayDateStart = DP_out.SelectedDate;
            DP_out.DisplayDateEnd = DP_out.SelectedDate.Value.AddDays(7);
        }

        private void DP_out_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            int days = Convert.ToInt32((DP_out.SelectedDate - DP_in.SelectedDate).Value.TotalDays);
            lbl_booking.Text = string.Format("{0} Nights {1} Days", days, (days + 1));
        }
    }
}