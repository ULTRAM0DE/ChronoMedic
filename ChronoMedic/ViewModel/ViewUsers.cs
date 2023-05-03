using ChronoMedic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronoMedic.ViewModel
{
    public class ViewUsers
    {
        public Database.User Users { get; set; }
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        
        public string LastName { get; set; }
        public string Email { get; set; }


        public ViewUsers(Database.User user)
        {
            Id = user.Id; 
            Users=user;
            Username = user.Username;
            Name = user.Name;
            LastName = user.LastName;
            Email = user.Email;
        }

    }
}
