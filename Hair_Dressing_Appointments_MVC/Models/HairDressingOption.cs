using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hair_Dressing_Appointments_MVC.Models
{
    public class HairDressingOption
    {

        //Hair dressing options
        public int Id { get; set; }

        public string OptionName { get; set; }

        public decimal Charge { get; set; }
    }
}
