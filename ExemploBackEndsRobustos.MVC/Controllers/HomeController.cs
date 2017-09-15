using ExemploBackEndsRobustos.Domain.Contracts.Services;
using System;
using System.Web.Mvc;

namespace ExemploBackEndsRobustos.MVC.Controllers
{
    public class HomeController : Controller
    {
        
        private IUserService _service;

        public HomeController(IUserService service)
        {
            this._service = service;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(FormCollection form)
        {           
            try
            {
                _service.Register(form["Nome"], form["Email"], form["Password"], form["ConfirmPassword"]);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("DefaultErrorMessage", ex.Message);
                return View(form);
            }
                      
        }
    }
}