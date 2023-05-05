using ChronoMedic.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using ChronoMedic.Database;
using System.Xml.Linq;
using System.Data.Entity.Migrations;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Windows;

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

        public static bool SaveEditUser(string username, string password,string name, string lastname, string email, ViewUsers selectedUser)
        {
            User user = selectedUser.Users;
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
                throw new Exception("Error Edit");
            }
            if (user == null)
            {
                return false;
            }
            try
            {
                MedicineEntities entities = new MedicineEntities();
                entities.User.AddOrUpdate(user);
                entities.SaveChanges();
                return true;
            }
            catch
            {
                throw new Exception("Ошибка редактирования пользователя");
            }
        }
        public static void DeleteUser(User currentUser)
        {
            if (currentUser == null)
            {
                MessageBox.Show("Don't pick user");
                return;
            }
            try
            {
                MedicineEntities entities = new MedicineEntities();
                entities.User.Remove(entities.User.Find(currentUser.Id));
                entities.SaveChanges();
            }
            catch
            {
                throw new Exception("Error to delete");
            }
        }
    }
}
