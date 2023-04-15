using Microsoft.EntityFrameworkCore;
using ProductDAL.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDAL
{
    public class AppointmentRepository:IRepository<Appointment>
    {
        AppointmentDbContext DbCtxt;

        public AppointmentRepository(AppointmentDbContext _db)
        {
            this.DbCtxt = _db;
        }

        public bool Add(Appointment entity)
        {
            DbCtxt.appointments.Add(entity);
            return DbCtxt.SaveChanges() > 0;
        }

        public bool DeleteById(int id)
        {
            var appointment_data = from Appointment apt in DbCtxt.appointments
                       where apt.Id == id
                       select apt;
            Appointment aptObj = appointment_data.SingleOrDefault();
            aptObj.Status = false;
            return DbCtxt.SaveChanges() > 0;
        }

        public IEnumerable<Appointment> FindByName(string name)
        {
            var obj = from Appointment apt in DbCtxt.appointments
                      where apt.Name.ToLower().StartsWith(name.ToLower()) && apt.AptDate >= DateTime.Now
                      select apt;
            return obj;
        }

        public IEnumerable<Appointment> GetAll()
        {
            var appointments = from Appointment apt in
                              DbCtxt.appointments
                              where apt.Status==true && apt.AptDate>=DateTime.Now
                           select apt;
            return appointments;
        }

        public Appointment GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Appointment entity)
        {
            throw new NotImplementedException();
        }
    }
}
