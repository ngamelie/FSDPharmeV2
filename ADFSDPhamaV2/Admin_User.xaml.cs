using ADFSDPhamaV2.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
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
    /// Interaction logic for Admin_User.xaml
    /// </summary>
    public partial class Admin_User : Window
    {
        public Admin_User()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            Tbl_User.Text = "User";
            BtnUpdate.IsEnabled = false;
            BtnDelete.IsEnabled = false;
            Tbx_email.Text = "";
            Tbx_password.Text = "";
            Tbx_id.Text = "";
            Combo_Role.SelectedIndex = 0;
            Combo_Role.ItemsSource = System.Enum.GetNames(typeof(EnumRole));

            PharmaConn pharmaConn = new PharmaConn();
            LvUser.ItemsSource = pharmaConn.Usrs.ToList();
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
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

        private void LvUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Usr currSelected = LvUser.SelectedItem as Usr;
            BtnUpdate.IsEnabled = (currSelected != null);
            BtnDelete.IsEnabled = (currSelected != null);
            if (currSelected == null)
            {
                init();
            }
            else
            {
                Tbx_id.Text = currSelected.id.ToString();
                Tbx_email.Text = currSelected.email;
                Combo_Role.Text = currSelected.role.ToString();
                Tbx_password.Text = currSelected.password;
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            string email = Tbx_email.Text;
            string pword = Tbx_password.Text;
            int role = Combo_Role.SelectedIndex;

            // validation

            Usr usr = new Usr();
            usr.email = email;
            usr.password = pword;

            switch (role)
            {
                case (int)EnumRole.admin:
                    usr.role = EnumRole.admin;
                    break;
                case (int)EnumRole.user:
                    usr.role = EnumRole.user;
                    break;
                default:
                    // code block
                    break;
            }

            if (Verify(usr))
            {
                PharmaConn pharmaConn = new PharmaConn();
                pharmaConn.Usrs.Add(usr);
                pharmaConn.SaveChanges();
            }
            else
            {
                return;
            }

            init();
            LvUser.SelectedItem = null;
            MessageBox.Show("New user created.");
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Usr usr = new Usr();
            usr.email = Tbx_email.Text;
            usr.password = Tbx_password.Text;
            usr.id = int.Parse(Tbx_id.Text);

            switch (Combo_Role.SelectedIndex)
            {
                case (int)EnumRole.admin:
                    usr.role = EnumRole.admin;
                    break;
                case (int)EnumRole.user:
                    usr.role = EnumRole.user;
                    break;
                default:
                    // code block
                    break;
            }

            if (Verify(usr))
            {
                PharmaConn pharmaConn = new PharmaConn();
                pharmaConn.Usrs.AddOrUpdate(usr);
                pharmaConn.SaveChanges();
            }
            else
            {
                return;
            }

            init();
            LvUser.SelectedItem = null;
            MessageBox.Show("User information updated.");
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            Usr currSelected = LvUser.SelectedItem as Usr;
            Usr usr = new Usr { id = currSelected.id };
            PharmaConn pharmaConn = new PharmaConn();
            pharmaConn.Usrs.Attach(usr);
            pharmaConn.Entry(usr).State = System.Data.Entity.EntityState.Deleted;
            pharmaConn.SaveChanges();
            init();
            LvUser.SelectedItem = null;
            MessageBox.Show("User information delete.");
        }

        private void BtnDash_Click(object sender, RoutedEventArgs e)
        {
            Admin window = new Admin();
            this.Visibility = Visibility.Hidden;
            window.Show();
        }

        private void BtnMedication_Click(object sender, RoutedEventArgs e)
        {
            //Admin_Medication window = new Admin_Medication();
            //this.Visibility = Visibility.Hidden;
            //window.Show();
        }

        private void BtnSupplier_Click(object sender, RoutedEventArgs e)
        {
            //Admin_Supplier window = new Admin_Supplier();
            //this.Visibility = Visibility.Hidden;
            //window.Show();
        }

        private void BtnStock_Click(object sender, RoutedEventArgs e)
        {
            Admin_Stock window = new Admin_Stock();
            this.Visibility = Visibility.Hidden;
            window.Show();
        }

        private void BtnCustomer_Click(object sender, RoutedEventArgs e)
        {
            //Admin_Customer window = new Admin_Customer();
            //this.Visibility = Visibility.Hidden;
            //window.Show();
        }

        private bool Verify(Usr usr)
        {
            bool rs = true;

            return rs;
        }
    }
}
