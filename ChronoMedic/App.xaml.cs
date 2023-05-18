using ChronoMedic.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;


namespace ChronoMedic
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected void ApplicationStart(object sender, StartupEventArgs e)
        {
            LoadingView loadnig = new LoadingView();
            loadnig.Show();
            Thread.Sleep(5000);
            loadnig.Hide();

            var loginView = new LoginView();
            loginView.Show();
            loginView.IsVisibleChanged += (s, ev) =>
            {

                if (loginView.IsVisible == false && loginView.IsLoaded)
                {
                    var mainView = new MainView();
                    mainView.Show();
                    //loginView.Close();
                }
            };
        }
    }
}
