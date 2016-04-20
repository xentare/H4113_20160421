using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tehtava3
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

        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(Properties.Settings.Default.DBConnection);
                builder.Password = txtBoxPassword.Password;
                builder.UserID = txtBoxUsername.Text;
                SqlConnection con = new SqlConnection(builder.ConnectionString);
                con.Open();
                if ((con.State & ConnectionState.Open) != 0)
                {
                    DataWindow dataWindow = new DataWindow();
                    //Application.Current.MainWindow = dataWindow;
                    this.Hide();
                    dataWindow.Show();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtBoxUsername_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
