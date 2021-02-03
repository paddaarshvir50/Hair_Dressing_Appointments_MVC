using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hair_Dressing_Appointments_MVC.Models;

namespace Hair_Dressing_Appointments_MVC.Data
{
    public class Hair_Dressing_Appointments_DBContext : DbContext
    {
        public Hair_Dressing_Appointments_DBContext (DbContextOptions<Hair_Dressing_Appointments_DBContext> options)
            : base(options)
        {
        }

        public DbSet<Hair_Dressing_Appointments_MVC.Models.Client> Client { get; set; }

        public DbSet<Hair_Dressing_Appointments_MVC.Models.HairDresser> HairDresser { get; set; }

        public DbSet<Hair_Dressing_Appointments_MVC.Models.HairDressingOption> HairDressingOption { get; set; }

        public DbSet<Hair_Dressing_Appointments_MVC.Models.Appointment> Appointment { get; set; }
    }
}
