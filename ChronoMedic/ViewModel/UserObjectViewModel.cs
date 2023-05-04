using ChronoMedic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ChronoMedic.ViewModel
{
    public class UserObjectViewModel: ViewModelBase
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
       
        public string Email { get; set; }
        
        private static MainViewModel _currentMain;

        public ICommand Save1 { get; }
        public ICommand Back1 { get; }


        public UserObjectViewModel()
        {
            Save1 = new ViewModelCommand(ExecutedSaveCommand);
            Back1 = new ViewModelCommand(ExecutedBackCommand);
        }

        public UserObjectViewModel(MainViewModel main)
        {
            _currentMain = main;
        }

        private void ExecutedBackCommand(object obj)
        {
            _currentMain.CurrentChildView = new CustomerViewModel();
            _currentMain.Caption = "Users";
            _currentMain.Icon = FontAwesome.Sharp.IconChar.User;
        }

        private void ExecutedSaveCommand(object obj)
        {
            try
            {
                FunctionUsers.Add(Username, Password, Name, LastName, Email);
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
    }
}
