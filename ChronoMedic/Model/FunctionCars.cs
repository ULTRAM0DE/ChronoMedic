using ChronoMedic.Database;
using ChronoMedic.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace ChronoMedic.Model
{
    public class FunctionCars
    {
        public static List<ViewCars> GetCars()
        {
            try
            {
                Database.MedicineEntities entities = new Database.MedicineEntities();
                var cars = entities.CarsData.ToList();
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

        public static bool AddCars(string numbercar, string status, string phone)
        {
            Database.CarsData cars = new Database.CarsData();
            try
            {
                cars.NumberCar = numbercar;
                cars.Status = status;
                cars.Phone = phone;


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
                entities.CarsData.Add(cars);
                entities.SaveChanges();
                return true;
            }
            catch
            {
                throw new Exception("Error Add Call");
            }

        }

        public static void DeleteCar(CarsData currentCar)
        {
            if (currentCar == null)
            {
                MessageBox.Show("Car not selected");
                return;
            }
            try
            {
                MedicineEntities entities = new MedicineEntities();
                entities.CarsData.Remove(entities.CarsData.Find(currentCar.Id));
                entities.SaveChanges();
            }
            catch
            {
                throw new Exception("Error to delete");
            }
        }

        public static bool SaveEditCar(string numbercar, string status, string phone, ViewCars selectedCar)
        {
            CarsData car = selectedCar.Car;
            try
            {
                car.NumberCar = numbercar;
                car.Status = status;
                car.Phone = phone;
            }
            catch
            {
                throw new Exception("Error Edit");
            }
            if (car == null)
            {
                return false;
            }
            try
            {
                MedicineEntities entities = new MedicineEntities();
                entities.CarsData.AddOrUpdate(car);
                entities.SaveChanges();
                return true;
            }
            catch
            {
                throw new Exception("Error Edit Car");
            }
        }
    }
}
