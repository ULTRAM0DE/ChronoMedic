using ChronoMedic.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronoMedic.Model
{
    public class FunctionCars
    {
        public static List<ViewCars> GetCars()
        {
            try
            {
                Database.MedicineEntities entities = new Database.MedicineEntities();
                var cars = entities.Cars.ToList();
                List<ViewCars> viewCars = new List<ViewCars>();
                foreach (var car in cars)
                    viewCars.Add(new ViewCars(car));
                return viewCars;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
