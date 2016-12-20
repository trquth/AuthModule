using Auth.Core.Interfaces.Services;
using Auth.Data.UnitOfWork;
using Auth.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Auth.Management.Areas.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly UnitOfWork unitOfWork = new UnitOfWork();
        private readonly IUserService _userService = null;
        public HomeController()
        {
            _userService = new UserService(unitOfWork);
        }
        public ActionResult Index()
        {          
            return View();
        }
    }
}