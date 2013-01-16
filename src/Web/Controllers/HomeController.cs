using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Messages;
using MassTransit;

namespace Web.Controllers
{
    public class CreateCustomerViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult Create(CreateCustomerViewModel model)
        {
            Bus.Instance.Publish(new CreateCustomerMessage 
            { 
                FirstName = model.FirstName, 
                LastName =  model.LastName,
                Id = Guid.NewGuid() 
            });
            return RedirectToAction("Index");
        }


        public ActionResult About()
        {
            return View();
        }
    }
}
