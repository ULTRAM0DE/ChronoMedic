using ChronoMedic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;

namespace ChronoMedic.ViewModel
{
    public class CallsObjectViewModel: ViewModelBase
    {
        public string NameCall { get; set; }
        public string LastNameCall { get; set; }
        public DateTime Data { get; set; }
        public string Adress { get; set; }
        public List<string> ResponsibleRider { get; set; }
        public string SelectedResponsibleRider { get; set; }
        public string Description { get; set; }
        private static bool IsEdit;
        private static ViewCalls SelectedCall;
        private static MainViewModel _currentMain;

        public ICommand Save { get; }
        public ICommand Back { get; }


        public CallsObjectViewModel()
        {
            
            ResponsibleRider = FunctionCalls.GetStringCalls();

            Save = new ViewModelCommand(ExecutedSaveCommand);
            Back = new ViewModelCommand(ExecutedBackCommand);

            if (IsEdit)
                SetCall();
        }

        public CallsObjectViewModel(MainViewModel main)
        {
            _currentMain = main;
            IsEdit= false;
        }
        public CallsObjectViewModel(MainViewModel main, ViewCalls selectedCall)
        {
            _currentMain = main;
            SelectedCall = selectedCall;
            IsEdit = true;
        }

        private void ExecutedBackCommand(object obj)
        {
            _currentMain.CurrentChildView = new CallsViewModel();
            _currentMain.Caption = "Calls";
            _currentMain.Icon = FontAwesome.Sharp.IconChar.Phone;
        }
        private void SetCall()
        {
            SelectedResponsibleRider = SelectedCall.ResponsibleRider;

            NameCall = SelectedCall.NameCall;
            LastNameCall = SelectedCall.LastNameCall;
            Data = SelectedCall.Data;
            Adress = SelectedCall.Adress;
            Description = SelectedCall.Description;

        }

        private void ExecutedSaveCommand(object obj)
        {
            if (!IsEdit)
            {
                try
                {
                    FunctionCalls.Add(NameCall, LastNameCall, Data, Adress, Description,SelectedResponsibleRider);
                }
                catch
                {
                    MessageBox.Show("Error");
                }
            }
            else
            {
                try
                {
                    FunctionCalls.SaveEditCall(NameCall, LastNameCall, Data, Adress, Description, SelectedCall);
                    MessageBox.Show("Edit Call");
                }
                catch
                {
                    MessageBox.Show("Error");
                }
            }
                
        }
    }
}
