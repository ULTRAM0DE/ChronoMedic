using ChronoMedic.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace ChronoMedic.Model
{
    public class FunctionUsers
    {
        public static List<ViewUsers> GetUsers()
        {
            try
            {
                Database.MedicineEntities entities = new Database.MedicineEntities();
                var users = entities.User.ToList();
                List<ViewUsers> viewUsers= new List<ViewUsers>();
                foreach(var user in users)
                    viewUsers.Add(new ViewUsers(user));
                return viewUsers;     
            }
            catch(Exception ex) 
            {
                throw new Exception(ex.ToString());
            }


        }
        public static bool Add(string username, string password, string name, string lastname, string email)
        {
            Database.User user = new Database.User();
            try
            {
                user.Username = username;
                user.Password = password;
                user.Name = name;
                user.LastName = lastname;
                user.Email = email;
                
            }
            catch
            {
                throw new Exception("Error Add");
            }
            if (user == null)
            {
                return false;
            }
            try
            {
                Database.MedicineEntities entities = new Database.MedicineEntities();
                entities.User.Add(user);
                entities.SaveChanges();
                return true;
            }
            catch
            {
                throw new Exception("Error Add User");
            }
        }

    }
}
