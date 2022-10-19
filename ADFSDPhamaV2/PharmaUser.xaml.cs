using ADFSDPhamaV2.Model;
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

namespace ADFSDPhamaV2
{
    /// <summary>
    /// Interaction logic for PharmaUser.xaml
    /// </summary>
    public partial class PharmaUser : Window
    {
        public PharmaUser(string username)
        {
            InitializeComponent();
            TblUser.Text = username;
        }    

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PharmaConn pharmaConn = new PharmaConn();
            Cbo_Customer.ItemsSource = pharmaConn.Customers.ToList();
            Cbo_Customer.DisplayMemberPath = "name";
            Cbo_Customer.SelectedValuePath = "id";
            Cbo_Customer.SelectedIndex = -1;

            Cbo_Medication.ItemsSource = pharmaConn.Medications.ToList();
            Cbo_Medication.DisplayMemberPath = "name";
            Cbo_Medication.SelectedValuePath = "id";
            Cbo_Medication.SelectedIndex = -1;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.Visibility = Visibility.Visible;
            this.Close();
        }

        private void Cbo_Customer_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            PharmaConn pharmaConn = new PharmaConn();
            int id = int.Parse(Cbo_Customer.SelectedValue.ToString());
            Customer customer = pharmaConn.Customers.Find(id);

            Tbx_id.Text = customer.id.ToString();
            Tbx_name.Text = customer.name.ToString();
            Tbx_phone.Text = customer.phone.ToString();
            Tbx_email.Text = customer.email.ToString();
            Tbx_address.Text = customer.address.ToString();
        }
    }
}
