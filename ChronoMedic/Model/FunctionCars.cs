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

        public static bool Add(string numbercar, string status, string numberphonerider)
        {
            Database.Cars cars = new Database.Cars();
            try
            {
                cars.NumberCar = numbercar;
                cars.Status = status;
                cars.NumberPhoneRider = numberphonerider;
                
                
            }
            catch
            {
                throw new Exception("Error Add");
            }
            if (cars == null)
            {
                return false;
            }
            try
            {
                Database.MedicineEntities entities = new Database.MedicineEntities();
                entities.Cars.Add(cars);
                entities.SaveChanges();
                return true;
            }
            catch
            {
                throw new Exception("Error Add Call");
            }
        }
    }
}
