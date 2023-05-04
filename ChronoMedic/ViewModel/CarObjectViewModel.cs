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
    public class CarObjectViewModel: ViewModelBase
    {
        public string NumberCar { get; set; }
        public string Status { get; set; }

        public string NumberPhoneRider { get; set; }

        private static MainViewModel _currentMain;

        public ICommand Save2 { get; }
        public ICommand Back2 { get; }


        public CarObjectViewModel()
        {
            Save2 = new ViewModelCommand(ExecutedSaveCommand);
            Back2 = new ViewModelCommand(ExecutedBackCommand);
        }

        public CarObjectViewModel(MainViewModel main)
        {
            _currentMain = main;
        }

        private void ExecutedBackCommand(object obj)
        {
            _currentMain.CurrentChildView = new HomeViewModel();
            _currentMain.Caption = "Cars";
            _currentMain.Icon = FontAwesome.Sharp.IconChar.Car;
        }

        private void ExecutedSaveCommand(object obj)
        {
            try
            {
                FunctionCars.Add(NumberCar, Status, NumberPhoneRider);
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
    }
}
