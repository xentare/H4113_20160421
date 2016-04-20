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

namespace Tehtava1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private static readonly char[] Characters = "abcdefghijklmnopqrstuvwxyzåäö".ToCharArray();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (txtBoxInput.Text != "")
            {
                if (!ContainsCharacter(txtBoxInput.Text))
                {
                    string[] split = txtBoxInput.Text.Split('.');
                    if (split.Length != 2)
                    {
                        textBlockOutput.Text = "Syötä päivämäärä muodossa DD.MM";
                        return;
                    }
                    int paiva, kuukausi;
                    paiva = Convert.ToInt32(split[0]);
                    kuukausi = Convert.ToInt32(split[1]);
                    textBlockOutput.Text = JAMK.ICT.NimiPaivat.HaeNimiPäivä(paiva, kuukausi);
                }
                else
                {
                    textBlockOutput.Text = JAMK.ICT.NimiPaivat.HaePäivä(txtBoxInput.Text);
                }
            }
        }

        public static bool ContainsCharacter(string text)
        {
            return text.IndexOfAny(Characters) >= 0;
        }

    }
}
