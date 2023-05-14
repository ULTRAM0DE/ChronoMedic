using ChronoMedic.Database;
using ChronoMedic.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;

namespace ChronoMedic.Model
{
    public class FunctionCalls
    {
        public static List<ViewCalls> GetCalls()
        {
            try
            {
                Database.MedicineEntities entities = new Database.MedicineEntities();
                var calls = entities.Calls.ToList();
                List<ViewCalls> viewCalls = new List<ViewCalls>();
                foreach (var call in calls)
                    viewCalls.Add(new ViewCalls(call));
                return viewCalls;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
       

        public static bool Add(string namecall, string lastnamecall, DateTime data, string adress, string description,string SelectedResponsibleRider)
        {
            Database.Calls calls = new Database.Calls();
            try
            {
                calls.NameCall = namecall;
                calls.LastNameCall = lastnamecall;
                calls.Data = data;
                calls.Adress = adress;
                calls.Description = description;
                calls.CarsData = GetRiderId(SelectedResponsibleRider);
            }
            catch
            {
                throw new Exception("Error Add");
            }
            if(calls == null)
            {
                return false;
            }
            try
            {
                Database.MedicineEntities entities = new Database.MedicineEntities();
                entities.Calls.Add(calls);
                entities.SaveChanges();
                
                return true;
            }
            catch
            {
                throw new Exception("Error Add Call");
            }
        }

        private static int GetRiderId(string selectedResponsibleRider)
        {
            MedicineEntities entities = new MedicineEntities();
            return entities.CarsData.Where(x => x.NumberCar == selectedResponsibleRider).First().Id;
        }

        public static void DeleteCall(Database.Calls currentCalls)
        {
            if (currentCalls == null)
            {
                MessageBox.Show("Отметка не выбрана");
                return;
            }
            try
            {
                MedicineEntities entities = new MedicineEntities();
                entities.Calls.Remove(entities.Calls.Find(currentCalls.Id));
                entities.SaveChanges();
            }
            catch
            {
                throw new Exception("Error to delete");
            }
        }

        public static List<string> GetStringCalls()
        {
            MedicineEntities entities = new MedicineEntities();
            return entities.CarsData.Select(x => x.NumberCar).ToList();
        }

        public static bool SaveEditCall(string namecall, string lastnamecall, DateTime data, string adress, string description, ViewCalls selectedCall, string SelectedResponsibleRider)
        {
            Calls calls = selectedCall.Call;
            try
            {
                calls.NameCall = namecall;
                calls.LastNameCall = lastnamecall;
                calls.Data = data;
                calls.Adress = adress;
                calls.Description = description;
                calls.CarsData = GetRiderId(SelectedResponsibleRider);


            }
            catch
            {
                throw new Exception("Error Edit");
            }
            if (calls == null)
            {
                return false;
            }
            try
            {
                
                MedicineEntities entities = new MedicineEntities();
                entities.Calls.AddOrUpdate(calls);
                entities.SaveChanges();
                return true;
            }
            catch
            {
                throw new Exception("Error Edit Call");
            }
        }
    }
}
