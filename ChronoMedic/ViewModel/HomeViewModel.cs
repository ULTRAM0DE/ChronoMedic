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
       

        public ICollectionView CurrentCallsList { get; private set; }
        public HomeViewModel()
        {
            List<ViewCalls> viewCalls = FunctionCalls.GetCalls();
            CurrentCallsList = CollectionViewSource.GetDefaultView(viewCalls);
        }
    }
}
