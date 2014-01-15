using KalkulatorMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KalkulatorMVC.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
       
        public ActionResult Index()
        {
            var model = new HomeModel();
           
                model.Test = "Modelowy";
            model.val = 5;
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(HomeModel model){

            int test = model.val;
          //  double res = double.Parse(result);
            //switch (button)
            //{
            //    case "n1":
            //        break;

            //}
            model.action = "a";
         
            return View(model);
        }


    

    }
}
