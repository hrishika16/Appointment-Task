using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDAL.EntityLayer
{
    public class AppointmentDbContext:DbContext
    {
        public AppointmentDbContext(DbContextOptions<AppointmentDbContext> opt) : base(opt)
        {
                
        }

        public DbSet<User> users { get; set; }
        public DbSet<Appointment> appointments { get; set; }
    }
}
