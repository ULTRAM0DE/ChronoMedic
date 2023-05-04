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
    public class CallsViewModel: ViewModelBase
    {
        private ICollectionView _currentCallsList;
        public ICollectionView CurrentCallsList
        {
            get { return _currentCallsList; }
            set
            {
                _currentCallsList = value;
                OnPropertyChanged(nameof(CurrentCallsList));
            }
        }

        public ICommand AddCall { get; }
        public ICommand Search { get; }
        public string CurrentText { get; set; }
        
       
        private static MainViewModel _currentMain;

        public CallsViewModel()
        {
            AddCall = new ViewModelCommand(ExecutedAddCallsCommand);
            Search = new ViewModelCommand(ExecutedSearchCallsCommand);
            

            List<ViewCalls> viewCalls = FunctionCalls.GetCalls();
            CurrentCallsList = CollectionViewSource.GetDefaultView(viewCalls);
        }

        private void ExecutedSearchCallsCommand(object obj)
        {
            if (CurrentText == null)
            {
                return;
            }
            if (CurrentText == string.Empty)
            {
                List<ViewCalls> viewCalls = FunctionCalls.GetCalls();
                CurrentCallsList = CollectionViewSource.GetDefaultView(viewCalls);
                return;

            }
            List<ViewCalls> viewCall = FunctionCalls.GetCalls();
            List<ViewCalls> view = viewCall.Where(x => x.NameCall.ToUpper().StartsWith(CurrentText.ToUpper()) || x.LastNameCall.ToUpper().StartsWith(CurrentText.ToUpper())).ToList();

            if (view.Count < 1)
            {
                MessageBox.Show("Not Found");
                CurrentText = string.Empty;
                List<ViewUsers> viewCalls = FunctionUsers.GetUsers();
                CurrentCallsList = CollectionViewSource.GetDefaultView(viewCalls);
                return;
            }

            CurrentCallsList = CollectionViewSource.GetDefaultView(view);
        }

        public CallsViewModel(MainViewModel main)
        {
            _currentMain = main;
        }
        

        private void ExecutedAddCallsCommand(object obj)
        {
            _currentMain.CurrentChildView = new CallsObjectViewModel(_currentMain);
            _currentMain.Caption = "AddCall";
            _currentMain.Icon = FontAwesome.Sharp.IconChar.Phone;
        }
    }
}
