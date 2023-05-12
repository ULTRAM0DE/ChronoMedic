using ChronoMedic.Model;
using FontAwesome.Sharp;
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
        private ICollectionView _currentUserList;
        public ICollectionView CurrentUsersList
        {
            get { return _currentUserList; }
            set
            {
                _currentUserList = value;
                OnPropertyChanged(nameof(CurrentUsersList));
            }
        }

        public ICommand AddUser { get; }
        public ICommand Search { get; }
        public ICommand EditUser { get; }
        public ViewUsers SelectedUser { get; set; }
        public ICommand DeleteUser { get; }
        public string CurrentText { get; set; }
        
        
        private static MainViewModel _currentMain;

        public CustomerViewModel()
        {
            AddUser = new ViewModelCommand(ExecutedAddUsersCommand);
            Search = new ViewModelCommand(ExecutedSearchUserCommand);
            DeleteUser = new ViewModelCommand(ExecutedDeleteUserCommand);
            EditUser = new ViewModelCommand(ExecutedEditUserCommand);

            Update();
            
        }

        private void ExecutedDeleteUserCommand(object obj)
        {
            FunctionUsers.DeleteUser(SelectedUser.Users);
            Update();
        }

        public void Update()
        {
            List<ViewUsers> viewUsers = FunctionUsers.GetUsers();
            CurrentUsersList = CollectionViewSource.GetDefaultView(viewUsers);
        }

        private void ExecutedEditUserCommand(object obj)
        {
            if (SelectedUser == null)
            {
                MessageBox.Show("User not selected");
                return;
            }
            _currentMain.CurrentChildView = new UserObjectViewModel(_currentMain, SelectedUser);
            _currentMain.Caption = "Edit User";
            _currentMain.Icon = IconChar.UserEdit;
        }

        private void ExecutedSearchUserCommand(object obj)
        {
            if(CurrentText == null)
            {
                return;
            }
            if(CurrentText == string.Empty)
            {
                List<ViewUsers> viewUsers = FunctionUsers.GetUsers();
                CurrentUsersList = CollectionViewSource.GetDefaultView(viewUsers);
                return;           
               
            }
            List<ViewUsers> viewUser = FunctionUsers.GetUsers();
            List<ViewUsers> view = viewUser.Where(x => x.Username.ToUpper().StartsWith(CurrentText.ToUpper()) || x.LastName.ToUpper().StartsWith(CurrentText.ToUpper())).ToList();

            if(view.Count < 1)
            {
                MessageBox.Show("Not Found");
                CurrentText = string.Empty;
                List<ViewUsers> viewUsers = FunctionUsers.GetUsers();
                CurrentUsersList = CollectionViewSource.GetDefaultView(viewUsers);
                return;
            }

            CurrentUsersList = CollectionViewSource.GetDefaultView(view);

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

