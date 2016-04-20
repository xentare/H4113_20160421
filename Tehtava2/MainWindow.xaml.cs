using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Serialization;

namespace Tehtava2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CustomerList list = new CustomerList();

        public MainWindow()
        {
            InitializeComponent();

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                list.ReadFile(txtBoxCsvFilePath.Text);
                dataGridOut.DataContext = list.Customers;
                string path = txtBoxCsvFilePath.Text;
                path = path.Replace("csv", "xml");
                txtBoxXMLPath.Text = path;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                XmlSerializer x = new XmlSerializer(typeof(CustomerList));

                var parse = from row in (List<Customer>)dataGridOut.ItemsSource
                            where row.XMLTiedostoon
                            select row;

                list.Customers = parse.ToList();

                TextWriter writer = new StreamWriter(txtBoxXMLPath.Text);

                x.Serialize(writer, list);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
