using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace ChronoMedic.View
{
    /// <summary>
    /// Логика взаимодействия для HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
        }

        private void TextBlock_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SamGMU_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://clinica.samsmu.ru/");
        }

        private void MiniSt_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://minzdrav.samregion.ru/");
        }
    }
}
