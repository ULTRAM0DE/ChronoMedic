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
    public class HomeViewModel: ViewModelBase
    {
        private static MainViewModel _currentMain;
        private ICollectionView _currentCarsList;

        public ICommand Search { get; }
        public ICommand AddCar { get; }
        public string CurrentText1 { get; set; }
        public ICollectionView CurrentCarsList
        {
            get { return _currentCarsList; }
            set
            {
                _currentCarsList = value;
                OnPropertyChanged(nameof(CurrentCarsList));
            }
        }
        public HomeViewModel()
        {
            Search = new ViewModelCommand(ExecutedSearchCarCommand);
            AddCar = new ViewModelCommand(ExecutedAddCarCommand);
            List<ViewCars> viewCars = FunctionCars.GetCars();
            CurrentCarsList = CollectionViewSource.GetDefaultView(viewCars);
        }

       private void ExecutedAddCarCommand(object obj)
        {
            _currentMain.CurrentChildView = new CarObjectViewModel(_currentMain);
            _currentMain.Caption = "AddCar";
            _currentMain.Icon = FontAwesome.Sharp.IconChar.Car;
        }

        private void ExecutedSearchCarCommand(object obj)
        {
            if (CurrentText1 == null)
            {
                return;
            }
            if (CurrentText1 == string.Empty)
            {
                List<ViewCars> viewCars = FunctionCars.GetCars();
                CurrentCarsList = CollectionViewSource.GetDefaultView(viewCars);
                return;

            }
            List<ViewCars> viewCar = FunctionCars.GetCars();
            List<ViewCars> view = viewCar.Where(x => x.NumberCar.ToUpper().StartsWith(CurrentText1.ToUpper()) || x.Status.ToUpper().StartsWith(CurrentText1.ToUpper())).ToList();

            if (view.Count < 1)
            {
                MessageBox.Show("Not Found");
                CurrentText1 = string.Empty;
                List<ViewCars> viewCars = FunctionCars.GetCars();
                CurrentCarsList = CollectionViewSource.GetDefaultView(viewCars);
                return;
            }

            CurrentCarsList = CollectionViewSource.GetDefaultView(view);
        }

        public HomeViewModel(MainViewModel main)
        {
            _currentMain = main;
        }
    }
}
