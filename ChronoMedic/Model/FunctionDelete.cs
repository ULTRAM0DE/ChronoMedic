using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronoMedic.Model
{
    public class FunctionDelete
    {
        public static void Delete(string path)
        {
            File.Delete(path);
        }
       
    }
}
