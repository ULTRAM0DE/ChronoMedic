using FontAwesome.Sharp;
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

namespace ChronoMedic.View
{
    /// <summary>
    /// Логика взаимодействия для InfoMessage.xaml
    /// </summary>
    public partial class InfoMessage : Window
    {
        public InfoMessage( string TextTitle, IconChar icon, Brush colorIcon)
        {
            InitializeComponent();
            
            
            textTitle.Text = TextTitle;
            ImageWindow.Icon = icon;
            ImageWindow.Foreground = colorIcon;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
