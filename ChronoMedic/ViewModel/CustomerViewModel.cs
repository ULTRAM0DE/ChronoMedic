using ChronoMedic.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace ChronoMedic.ViewModel
{
    public class CustomerViewModel: ViewModelBase
    {
        public ICollectionView CurrentUsersList { get; private set; }

        public ICommand AddUser { get; }
        
        
        private static MainViewModel _currentMain;

        public CustomerViewModel()
        {
            AddUser = new ViewModelCommand(ExecutedAddUsersCommand);
           

            List<ViewUsers> viewUsers = FunctionUsers.GetUsers();
            CurrentUsersList = CollectionViewSource.GetDefaultView(viewUsers);
        }

        public CustomerViewModel(MainViewModel main)
        {
            _currentMain = main;
        }
       

        private void ExecutedAddUsersCommand(object obj)
        {
            _currentMain.CurrentChildView = new UserObjectViewModel(_currentMain);
            _currentMain.Caption = "AddUser";
            _currentMain.Icon = FontAwesome.Sharp.IconChar.User;

        }
    }
}

