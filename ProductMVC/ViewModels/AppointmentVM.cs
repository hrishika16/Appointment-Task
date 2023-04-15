using ProductDAL;
using ProductDAL.EntityLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductMVC.ViewModels
{
    public class AppointmentVM
    {
       
        public AppointmentVM()
        {
            status = true;
        }
        public int AppointmentId { get; set; }
        public string AppointmentName { get; set; }
        public string AppointmentEmail { get; set; }
        public string AppointmentTitle { get; set; }
        public DateTime AppointmentDate { get; set; }

        public bool status { get; set; }
       
        //public int UserId { get; set; }
        //public IEnumerable<User> User { get; set; }
    }
}
