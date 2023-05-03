using ChronoMedic.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace ChronoMedic.ViewModel
{
    public class CallsViewModel: ViewModelBase
    {
        public ICollectionView CurrentCallsList { get; private set; }

        public ICommand AddCall { get; }
        
       
        private static MainViewModel _currentMain;

        public CallsViewModel()
        {
            AddCall = new ViewModelCommand(ExecutedAddCallsCommand);
            

            List<ViewCalls> viewCalls = FunctionCalls.GetCalls();
            CurrentCallsList = CollectionViewSource.GetDefaultView(viewCalls);
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
