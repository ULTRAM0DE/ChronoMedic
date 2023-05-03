using ChronoMedic.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static bool Add(string namecall, string lastnamecall, DateTime data, string adress, string description)
        {
            Database.Calls calls = new Database.Calls();
            try
            {
                calls.NameCall = namecall;
                calls.LastNameCall = lastnamecall;
                calls.Data = data;
                calls.Adress = adress;
                calls.Description = description;
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

         
    }
}
