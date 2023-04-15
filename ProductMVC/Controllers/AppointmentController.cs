using Microsoft.AspNetCore.Mvc;
using ProductDAL.EntityLayer;
using ProductDAL;
using ProductMVC.ViewModels;
using System;

namespace ProductMVC.Controllers
{
    [Route("aptdata")]
    public class AppointmentController : Controller
    {
        IRepository<Appointment> _appointmentRepository;
        IRepository<User> _userRepository;
        public AppointmentController(IRepository<Appointment> ref1, IRepository<User> ref2)
        {
            _userRepository = ref2;
            _appointmentRepository = ref1;
        }
        [Route("index")]
        [HttpGet]
        public IActionResult Index()
        {
            AppointmentVM appointmentVM = new AppointmentVM();
            return View(_appointmentRepository.GetAll());
        }

        [Route("index")]
        [HttpPost]
        public IActionResult Index(string s)
        {
            s = Request.Form["searchTxt"];
            return View(_appointmentRepository.FindByName(s));
        }

        [Route("add")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [Route("add")]
        [HttpPost]
        public IActionResult Add(AppointmentVM apt)
        {
            Console.WriteLine(apt);
            bool isAdded=_appointmentRepository.Add(new Appointment()
            {
                Name = apt.AppointmentName,
                Email = apt.AppointmentEmail,
                Title = apt.AppointmentTitle,
                AptDate = apt.AppointmentDate,
                Status=apt.status

            }) ;
            if (isAdded)
            {
                return RedirectToAction("index");
            }

            return RedirectToAction("/");
        }

        [Route("delete")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _appointmentRepository.DeleteById(id);
            return RedirectToAction("index");
        }




    }
}
