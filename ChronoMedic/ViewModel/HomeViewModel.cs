﻿using ChronoMedic.Model;
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
        private ICollectionView _currentCarsList;
        public ICollectionView CurrentCarsList
        {
            get { return _currentCarsList; }
            set
            {
                _currentCarsList = value;
                OnPropertyChanged(nameof(CurrentCarsList));
            }
        }

        public ICommand AddCar { get; }
        public ICommand Search { get; }
        public string CurrentText { get; set; }


        private static MainViewModel _currentMain;

        public HomeViewModel()
        {
            AddCar = new ViewModelCommand(ExecutedAddCarsCommand);
            Search = new ViewModelCommand(ExecutedSearchCarsCommand);


            List<ViewCars> viewCars = FunctionCars.GetCars();
            CurrentCarsList = CollectionViewSource.GetDefaultView(viewCars);
        }

        private void ExecutedSearchCarsCommand(object obj)
        {
            if (CurrentText == null)
            {
                return;
            }
            if (CurrentText == string.Empty)
            {
                List<ViewCars> viewCars = FunctionCars.GetCars();
                CurrentCarsList = CollectionViewSource.GetDefaultView(viewCars);
                return;

            }
            List<ViewCars> viewCar = FunctionCars.GetCars();
            List<ViewCars> view = viewCar.Where(x => x.NumberCar.ToUpper().StartsWith(CurrentText.ToUpper()) || x.Status.ToUpper().StartsWith(CurrentText.ToUpper())).ToList();

            if (view.Count < 1)
            {
                MessageBox.Show("Not Found");
                CurrentText = string.Empty;
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


        private void ExecutedAddCarsCommand(object obj)
        {
            _currentMain.CurrentChildView = new CarObjectViewModel(_currentMain);
            _currentMain.Caption = "AddCar";
            _currentMain.Icon = FontAwesome.Sharp.IconChar.Phone;
        }
    }
}
