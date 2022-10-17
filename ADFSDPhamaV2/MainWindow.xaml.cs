using ADFSDPhamaV2.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ADFSDPhamaV2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            Storyboard sb = Resources["OpenMenu"] as Storyboard;
            sb.Begin(LeftMenu);
            TbxUsername.Text = "";
            PbxPassword.Password = "";
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {




            PharmaConn pharmaConn = new PharmaConn();


            string uname = TbxUsername.Text;
            string pword = PbxPassword.Password.ToString();


            //Usr rs = pharmaConn.Usrs.Find(1, uname, pword);
            Usr rs = pharmaConn.Usrs.Find(1);

            if (rs == null)
            {
                MessageBox.Show("Invalid username and password");
            }
            else
            {
                Admin admin = new Admin();
                this.Visibility = Visibility.Hidden;
                admin.Show();

                /*
                if(rs.role == EnumRole.admin)
                {
                    Admin admin = new Admin();
                    this.Visibility = Visibility.Hidden;
                    admin.Show();
                }
                else if (rs.role == EnumRole.user)
                {

                }
                else
                {
                    MessageBox.Show("Please contact your system administrator.");
                }
                */
            }
                




            
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Storyboard sb = Resources["CloseMenu"] as Storyboard;
            sb.Begin(LeftMenu);
        }
    }
}
