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
        void hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://minzdrav.samregion.ru"); //открытие ссылки в браузере

        }
        void hyperlink_Click1(object sender, RoutedEventArgs e)
        {
            Process.Start("https://clinica.samsmu.ru/"); //открытие ссылки в браузере

        }

        private void CountCalls_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
