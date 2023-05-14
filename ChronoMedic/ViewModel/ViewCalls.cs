using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronoMedic.ViewModel
{
    public class ViewCalls
    {
        public Database.Calls Call { get; set; }
        public int Id { get; set; }
        public string NameCall { get; set; }

        public string ResponsibleRider { get; set; }

        public string LastNameCall { get; set; }
        public DateTime Data { get; set; }
        public string Adress { get; set; }
        public string Description { get; set; }
        public string CarNumber { get; set; }


        public ViewCalls(Database.Calls call)
        {
            Id = call.Id;
            Call = call;
            NameCall = call.NameCall;
            LastNameCall = call.LastNameCall;
            Data = (DateTime)call.Data;
            Adress = call.Adress;
            Description = call.Description;
           

            if(call.CarsData1 == null)
            {
                CarNumber = null;
            }
            else
            {
                CarNumber = call.CarsData1.NumberCar;
            }

            

            
        }
    }
}
