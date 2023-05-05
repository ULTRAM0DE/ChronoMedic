using ChronoMedic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;

namespace ChronoMedic.ViewModel
{
    public class CarObjectViewModel: ViewModelBase
    {
        public string NumberCar { get; set; }
        public string Status { get; set; }

        public string Phone { get; set; }
        private static bool IsEdit;
        private static ViewCars SelectedCar;

        private static MainViewModel _currentMain;

        public ICommand Save2 { get; }
        public ICommand Back2 { get; }


        public CarObjectViewModel()
        {
            Save2 = new ViewModelCommand(ExecutedSaveCommand);
            Back2 = new ViewModelCommand(ExecutedBackCommand);

            if (IsEdit)
                SetCar();
        }

        private void SetCar()
        {
            NumberCar = SelectedCar.NumberCar;
            Status = SelectedCar.Status;
            Phone = SelectedCar.Phone;
        }

        public CarObjectViewModel(MainViewModel main)
        {
            _currentMain = main;
            IsEdit = false;
        }

        public CarObjectViewModel(MainViewModel main, ViewCars selectedCar)
        {
            _currentMain = main;
            SelectedCar = selectedCar;
            IsEdit = true;
        }

        private void ExecutedBackCommand(object obj)
        {
            _currentMain.CurrentChildView = new HomeViewModel();
            _currentMain.Caption = "Home";
            _currentMain.Icon = FontAwesome.Sharp.IconChar.Home;
        }

        private void ExecutedSaveCommand(object obj)
        {
            if (!IsEdit)
            {
                try
                {
                    FunctionCars.AddCars(NumberCar, Status, Phone);
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
                    FunctionCars.SaveEditCar(NumberCar, Status, Phone, SelectedCar);
                    MessageBox.Show("Edit Car");
                }
                catch
                {
                    MessageBox.Show("Error");
                }
            }
                
        }
    }
}
