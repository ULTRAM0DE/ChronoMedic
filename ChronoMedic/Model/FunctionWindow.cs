using ChronoMedic.View;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronoMedic.Model
{
    public class FunctionWindow
    {
        public static void OpenErrorWindow(string text)
        {
            InfoMessage errorView = new InfoMessage("Ошибка", IconChar.Xmark, Brushes.Red);
            errorView.Show();
        }

        public static void OpenGoodWindow(string text)
        {
            InfoMessage errorView = new InfoMessage("Успешно", IconChar.Check, Brushes.Green);
            errorView.Show();
        }

        public static void OpenConfrumWindow(string text)
        {
            InfoMessage errorView = new InfoMessage("Предупреждение", IconChar.Exclamation, Brushes.Yellow);
            errorView.Show();
        }

        
    }
}
