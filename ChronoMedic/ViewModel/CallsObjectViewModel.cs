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
    public class CallsObjectViewModel: ViewModelBase
    {
        public string NameCall { get; set; }
        public string LastNameCall { get; set; }
        public DateTime Data { get; set; }
        public string Adress { get; set; }
        public string Description { get; set; }
        private static MainViewModel _currentMain;

        public ICommand Save { get; }
        public ICommand Back { get; }


        public CallsObjectViewModel()
        {
            Save = new ViewModelCommand(ExecutedSaveCommand);
            Back = new ViewModelCommand(ExecutedBackCommand);
        }

        public CallsObjectViewModel(MainViewModel main)
        {
            _currentMain = main;
        }

        private void ExecutedBackCommand(object obj)
        {
            _currentMain.CurrentChildView = new CallsViewModel();
            _currentMain.Caption = "Calls";
            _currentMain.Icon = FontAwesome.Sharp.IconChar.Phone;
        }

        private void ExecutedSaveCommand(object obj)
        {
            try
            {
                FunctionCalls.Add(NameCall, LastNameCall, Data, Adress, Description);
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
    }
}
