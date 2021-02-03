using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hair_Dressing_Appointments_MVC.Models
{
    public class HairDresser
    {
        //Hair dresser details
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsPermanent { get; set; }
    }
}
