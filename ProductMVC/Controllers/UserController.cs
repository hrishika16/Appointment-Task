using Microsoft.AspNetCore.Mvc;
using ProductDAL.EntityLayer;
using ProductDAL;
using ProductMVC.ViewModels;
using System;
using System.Linq;

namespace ProductMVC.Controllers
{
    [Route("userdata")]
    public class UserController : Controller
    {
        IRepository<User> _userRepository;
        public UserController( IRepository<User> ref2)
        {
            _userRepository = ref2;
        }

        [Route("signup")]
        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        [Route("signup")]
        [HttpPost]
        public IActionResult Signup(UserVM usrObj)
        {
            Console.WriteLine(usrObj);
            bool isAdded = _userRepository.Add(new User()
            {
                Id = usrObj.Id,
                Email = usrObj.Email,
                Password = usrObj.Password,
               

            });
            if (isAdded)
            {
                return Redirect("/aptdata/index");
            }

            return RedirectToAction("/");
        }



        [Route("login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [Route("login")]
        [HttpPost]
        public IActionResult Login(UserVM usrObj)
        {
            try
            {
                Console.WriteLine(usrObj);
                var obj = _userRepository.FindByName(usrObj.Email).ToList()[0];
                if (obj.Password.Equals(usrObj.Password))
                {
                    return Redirect("/aptdata/index");
                }

            }
            catch (Exception er)
            {
                return Redirect("/userdata/login");
            }


            return Redirect("/userdata/login");
        }

    }
}
