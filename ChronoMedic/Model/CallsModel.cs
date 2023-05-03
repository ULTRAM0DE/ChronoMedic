using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronoMedic.Model
{
    public class CallsModel
    {
        public int Id { get; set; }
        public string NameCall { get; set; }
        public string LastNameCall { get; set; }
        public DateTime Data { get; set; }
        public string Adress { get; set; }
        public string Description { get; set; }
    }
}
