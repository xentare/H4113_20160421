using System;
using System.Collections.Generic;
using System.Data;
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
using System.Linq;

namespace Tehtava3
{
    /// <summary>
    /// Interaction logic for DataWindow.xaml
    /// </summary>
    public partial class DataWindow : Window
    {
        private DataTable table;

        public DataWindow()
        {
            InitializeComponent();
            InitData();
            InitCountries();
        }

        private void InitData()
        {
            try
            {
                table = DBViinit.GetData("SELECT * FROM wine").Tables[0];
                DataGridWines.DataContext = table;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void InitCountries()
        {
            DataTable table = (DataTable) DataGridWines.DataContext;
            var countries = from DataRow row in table.AsEnumerable()
                select row.Field<string>("country");

            cbCountries.ItemsSource = countries.Distinct();
        }

        private void cbCountries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            table.DefaultView.RowFilter = string.Format("country = '{0}'", cbCountries.SelectedValue);
        }

        private void btnCountWines_Click(object sender, RoutedEventArgs e)
        {
            string text = "";
            foreach (var country in cbCountries.ItemsSource)
            {
                var count = from DataRow row in table.AsEnumerable()
                    where row.Field<string>("country") == (string)country
                    select row;
                text += country.ToString() + ": " + count.Count() + " viiniä ";
            }
            txtBoxWineCounts.Text = text;
        }
    }
}
