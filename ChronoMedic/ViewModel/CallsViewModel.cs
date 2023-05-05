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
        public ICommand EditCall { get; }
        public ViewCalls SelectedCall { get; set; }
        public ICommand DeleteCall { get; }
        public string CurrentText { get; set; }
        
       
        private static MainViewModel _currentMain;

        public void Update()
        {
            List<ViewCalls> viewCalls = FunctionCalls.GetCalls();
            CurrentCallsList = CollectionViewSource.GetDefaultView(viewCalls);
        }

        public CallsViewModel()
        {
            AddCall = new ViewModelCommand(ExecutedAddCallsCommand);
            Search = new ViewModelCommand(ExecutedSearchCallsCommand);
            EditCall = new ViewModelCommand(ExecutedEditCallCommand);
            DeleteCall = new ViewModelCommand(ExecutedDeleteCallCommand);


            Update();
        }

        private void ExecutedEditCallCommand(object obj)
        {
            if (SelectedCall == null)
            {
                MessageBox.Show("Call not selected");
                return;
            }
            _currentMain.CurrentChildView = new CallsObjectViewModel(_currentMain);
            _currentMain.Caption = "Edit Call";
            _currentMain.Icon = IconChar.FileEdit;
        }

        private void ExecutedDeleteCallCommand(object obj)
        {
            FunctionCalls.DeleteCall(SelectedCall.Call);
            Update();
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
