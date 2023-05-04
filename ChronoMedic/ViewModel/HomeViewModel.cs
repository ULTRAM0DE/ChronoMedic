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
    public class HomeViewModel: ViewModelBase
    {
        private static MainViewModel _viewModel;
       

        public ICollectionView CurrentCarsList { get; private set; }
        public HomeViewModel()
        {
            List<ViewCars> viewCars = FunctionCars.GetCars();
            CurrentCarsList = CollectionViewSource.GetDefaultView(viewCars);
        }

        public HomeViewModel(MainViewModel main)
        {
            _viewModel = main;
        }
    }
}
