using ChronoMedic.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace ChronoMedic.ViewModel
{
    public class ViewCars
    {
        public Database.Cars Car { get; set; }
        public int Id { get; set; }
        public string NumberCar { get; set; }
        public string Status { get; set; }
        public string NumberPhoneRider { get; set; }


        public ViewCars(Database.Cars car)
        {
            Id = car.Id;
            Car = car;
            NumberCar = car.NumberCar;
            Status = car.Status;
            NumberPhoneRider= car.NumberPhoneRider;
            
        }
    }
}
