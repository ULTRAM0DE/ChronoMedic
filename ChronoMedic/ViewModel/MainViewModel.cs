using ChronoMedic.Model;
using ChronoMedic.Repositories;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ChronoMedic.ViewModel
{
    public class MainViewModel: ViewModelBase
    {
        private UserAccountModel _currentUserAccount;
        private ViewModelBase _currentChildView;
        private string caption;
        private IconChar _icon;
        private IUserRepository userRepository;
        public UserAccountModel CurrentUserAccount
        {
            get
            {
                return _currentUserAccount;
            }
            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }
        public MainViewModel()
        {
            userRepository = new UserRepository();
            CurrentUserAccount= new UserAccountModel();
            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeCommand);
            ShowCustomerCommand = new ViewModelCommand(ExecuteShowCustomerCommand);
            ShowCallsCommand = new ViewModelCommand(ExecuteShowCallsCommand);


            ExecuteShowHomeCommand(null);
            LoadCurrentUserData();
        }

        private void ExecuteShowCallsCommand(object obj)
        {
            CurrentChildView = new CallsViewModel(this);
            Caption = "Calls";
            Icon = IconChar.Phone;
        }

        private void ExecuteShowCustomerCommand(object obj)
        {
            CurrentChildView = new CustomerViewModel(this);
            Caption = "Users";
            Icon = IconChar.UserGroup;
        }

        private void ExecuteShowHomeCommand(object obj)
        {
            CurrentChildView = new HomeViewModel();
            Caption = "Home";
            Icon = IconChar.Home;
        }

        public ViewModelBase CurrentChildView
        {
            get
            {
                return _currentChildView;
            }
            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }
        public string Caption
        {
            get
            {
                return caption;
            }
            set
            {
                caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }
        public IconChar Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }

        public ICommand ShowHomeViewCommand { get; }
        public ICommand ShowCustomerCommand { get; }
        public ICommand ShowCallsCommand { get; }
        private void LoadCurrentUserData()
        {
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if(user != null)
            {
                CurrentUserAccount.Username = user.Username;
                CurrentUserAccount.DisplayName = $"{user.Name} {user.LastName}";
                CurrentUserAccount.ProfilePicture = null; 
            }
            else
            {
                CurrentUserAccount.DisplayName="Invalid user";
                
            }
        }
    }
}
