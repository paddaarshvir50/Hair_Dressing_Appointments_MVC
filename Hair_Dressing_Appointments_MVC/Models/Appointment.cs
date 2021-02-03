using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hair_Dressing_Appointments_MVC.Models
{
    public class Appointment
    {
        //Appointment details
        public int Id { get; set; }

        public int ClientId { get; set; }

        public int HairDresserId { get; set; }

        public int HairDressingOptionId { get; set; }

        public Client Client { get; set; }

        public HairDresser HairDresser { get; set; }

        public HairDressingOption HairDressingOption { get; set; }



    }
}

