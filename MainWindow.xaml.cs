using P1_AP1_Felix_20180570.UI.Consultas;
using P1_AP1_Felix_20180570.UI.Registros;
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

namespace P1_AP1_Felix_20180570
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

        private void AportesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rAportes ra = new rAportes();

            ra.Show();
        }

        private void ConsultaAportesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cAportes ca = new cAportes();
            ca.Show();
        }

        private void AportesButton_Click(object sender, RoutedEventArgs e)
        {
            rAportes ra = new rAportes();

            ra.Show();
        }

        private void CAportesButton_Click(object sender, RoutedEventArgs e)
        {
            cAportes ca = new cAportes();
            ca.Show();
        }

        private void CAportesButton_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
